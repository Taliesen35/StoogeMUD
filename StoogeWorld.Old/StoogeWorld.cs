using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StoogeWorld.Things.Areas;
using StoogeWorld.Things.Commands;
using StoogeWorld.Things.Effects;
using StoogeWorld.Things.Mobs.Players;

namespace StoogeWorld
{
	public class StoogeWorld
	{
		public static List<Player> Players { get; set; }
		public static List<Area> Areas { get; set; }
		public static List<ICommand> Commands { get; set; }
		 
		public static Dictionary<int, IEffect> Effects { get; set; } 

		public StoogeWorld()
		{
			Players = new List<Player>();
			Areas = new List<Area>();
			Commands = new List<ICommand>();
		}
		
		public bool Load()
		{
			Console.WriteLine("Loading the world...");

			LoadAreas();
			LoadPlayers();
			LoadCommands();

			return true;
		}

		private static void LoadPlayers()
		{
			Console.WriteLine("Begin loading of player files");

			var d = new DirectoryInfo(@"../../data/players/");
			var files = d.GetFiles("*.player");

			foreach ( var file in files )
			{
				var player = new Player(file.Name.Substring(0, file.Name.IndexOf('.')));
				player = (Player)player.Load(file.Name);
				Players.Add(player);
			}

			Console.WriteLine($"Successfully loaded {Players.Count} players.");
		}

		private static void LoadAreas()
		{
			Console.WriteLine("Begin loading of area files");

			var d = new DirectoryInfo(@"../../data/areas/");
			var files = d.GetFiles("*.area");

			foreach ( var file in files )
			{
				var area = new Area(file.Name.Substring(0,file.Name.IndexOf('.')));
				area = (Area)area.Load(file.Name);
				Areas.Add(area);
			}

			Console.WriteLine($"Successfully loaded {Areas.Count} areas.");
		}

		private static void LoadCommands()
		{
			Console.WriteLine("Begin loading of commands");
			var d = new DirectoryInfo(@"../../data/commands/");
			var files = d.GetFiles("*.comm");
			
			foreach ( var file in files )
			{
				var commandName = file.Name.Substring(0, file.Name.IndexOf('.'));

				var type = Type.GetType($"StoogeWorld.Things.Commands.{commandName}Command");
				var cmdType = Activator.CreateInstance(type, commandName);
				var execute = type?.GetMethod("Load");
				var cmd = execute?.Invoke(cmdType, new object[]{commandName});
				Commands.Add((ICommand)cmd);
			}

			Console.WriteLine($"Successfully loaded {Commands.Count} commands.");
		}

		public static void Send(string message)
		{
			foreach (var p in Players)
			{
				p.Send(message);
			}
		}

		public DateTime Pulse(DateTime lastPulse)
		{
			//Move NPCs
			foreach (var m in Areas.SelectMany(a => a.Npcs).Where(m => (DateTime.Now - lastPulse).TotalMilliseconds >= m.Value.MovePulse))
			{
				m.Value.Pulse();
			}
			return DateTime.Now;
		}
	}
}
