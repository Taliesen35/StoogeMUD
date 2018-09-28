using Newtonsoft.Json;

namespace StoogeWorld.Things
{
	public class Thing : IThing
	{
		[JsonProperty(Order = 1)]
		public int Id { get; set; }
		[JsonProperty(Order = 2)]
		public string Name { get; set; }
		[JsonProperty(Order = 3)]
		public string Description { get; set; }
		[JsonProperty(Order = 4)]
		public int Weight { get; set; }

		public virtual bool Save()
		{
			return true;
		}
		public virtual IThing Load(string name)
		{
			return new Thing();
		}

		public virtual void Send(string message)
		{
			
		}
	}
}
