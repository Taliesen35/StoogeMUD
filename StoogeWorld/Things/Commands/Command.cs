using StoogeWorld.Things.Mobs.Players;

namespace StoogeWorld.Things.Commands
{
	public interface ICommand
	{
		Thing Target { get; set; }
		string UserText { get; set; }
		string TargetText { get; set; }
		string RoomText { get; set; }
		string AreaText { get; set; }
		string WorldText { get; set; }
		int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		int Weight { get; set; }
		bool Save();
		IThing Load(string name);
		void Execute(Player p, string[] args);
		void Send(string message);
	}

	public abstract class Command : Thing, ICommand
	{
		public static string CommandDirectory = "../../data/commands/";

		public Thing Target { get; set; }
		public string UserText { get; set; }
		public string TargetText { get; set; }
		public string RoomText { get; set; }
		public string AreaText { get; set; }
		public string WorldText { get; set; }

		protected Command(string name)
		{
			Name = name;
		}
		public override bool Save()
		{
			return false;
		}

		public abstract override IThing Load(string name);

		public virtual void Execute(Player p, string[] args)
		{
			p.Send($"{UserText}");
			Target?.Send(TargetText);
			p.CurrentRoom.Send(RoomText);
			p.CurrentRoom.ParentArea.Send(AreaText);
			StoogeWorld.Send(WorldText);
		}
	}
}
