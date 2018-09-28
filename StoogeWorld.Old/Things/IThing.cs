namespace StoogeWorld.Things
{
	public interface IThing
	{
		bool Save();
		IThing Load(string name);
	}
}
