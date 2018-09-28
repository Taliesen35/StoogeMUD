using System;
using System.IO;
using Newtonsoft.Json;
using StoogeWorld.Things.Mobs.Players;

namespace StoogeWorld.Things.Commands
{
	internal class SayCommand : Command
	{
		public SayCommand(string name) : base(name)
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
			try
			{
				base.Execute(p, args);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Move command failed. " + ex.Message);
			}
		}
	}
}
