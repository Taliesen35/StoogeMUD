using StoogeWorld.Things.Mobs.Players;

namespace StoogeWorld.Things.Effects
{
	public interface IEffect
	{
		void Apply(Thing p);
		bool Save();
		IThing Load(string name);
		int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		int Weight { get; set; }
		void Send(string message);
	}

	public class Effect : Thing, IEffect
	{
		public virtual void Apply(Thing p)
		{

		}
		public override bool Save()
		{
			return false;
		}
		public override IThing Load(string name)
		{
			return new Effect();
		}
	}
}
