using System;
using System.IO;
using Newtonsoft.Json;
using StoogeWorld.Things.Areas;
using StoogeWorld.Things.Mobs.Players;
using StoogeWorld.Utiltities;

namespace StoogeWorld.Things.Commands
{
	internal class MoveCommand : Command
	{
		private Direction _direction = Direction.None;

		public MoveCommand(string name) : base(name)
		{
		}

		public override IThing Load(string name)
		{
			using ( var r = new StreamReader(CommandDirectory + name + ".comm") )
			{
				var json = r.ReadToEnd();
				var command = JsonConvert.DeserializeObject<MoveCommand>(json);
				return command;
			}
		}

		public override void Execute(Player p, string[] args)
		{
			_direction = GetDirection(args[0]);

			try
			{
				p.Move(_direction);
				base.Execute(p, args);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Move command failed. Exception: {ex}");
			}
		}
		
		private static Direction GetDirection(string dir)
		{
			switch (dir.ToLower())
			{
				case "north":
				case "n":
					return Direction.North;
				case "south":
				case "s":
					return Direction.South;
				case "east":
				case "e":
					return Direction.East;
				case "west":
				case "w":
					return Direction.West;
				case "up":
				case "u":
					return Direction.Up;
				case "down":
				case "d":
					return Direction.Down;
				default:
					return Direction.None;
			}
		}
	}
}
