namespace StoogeWorld.Things.Items
{
	public class Item : Thing, IThing
	{
		public bool Wearable { get; set; }
		public bool Edible { get; set; }
		public bool Cursed { get; set;}
		public bool Money { get; set; }

		public override bool Save()
		{
			return false;
		}
		public override IThing Load(string name)
		{
			return new Item();
		}
	}
}
