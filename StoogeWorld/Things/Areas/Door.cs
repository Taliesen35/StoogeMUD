using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StoogeWorld.Things.Areas
{
	public class Door : Thing
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public DoorState State { get; set; }
		public int Key { get; set; }
		public int Strength { get; set; }
	}

	public enum DoorState
	{
		Locked,
		Closed,
		Ajar,
		Open
	}
}
