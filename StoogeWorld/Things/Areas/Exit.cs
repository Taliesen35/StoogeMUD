using System.Collections.Generic;
using StoogeWorld.Things.Effects;

namespace StoogeWorld.Things.Areas
{
	public class Exit : Thing
	{
		public int OriginationRoom { get; set; }
		public int DestinationRoom { get; set; }

		public int[] Effects { get; set; }
		public Door Door { get; set; }

	}
}
