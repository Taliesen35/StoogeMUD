using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StoogeWorld.Things.Areas;
using StoogeWorld.Things.Effects;
using StoogeWorld.Things.Items;
using StoogeWorld.Utiltities;

namespace StoogeWorld.Things.Mobs
{
	public class Mobile : Thing, IMobile
	{
		[JsonProperty(Order = 5)]
		public List<Item> Inventory { get; set; }
		[JsonProperty(Order = 6)]
		public List<Item> Equipped { get; set; }
		[JsonProperty(Order = 7)]
		public Dictionary<string, bool> Flags { get; set; }
		[JsonProperty(Order = 8)]
		public Room CurrentRoom { get; set; }

		public virtual void Move(Direction dir)
		{
			bool immune;

			Flags.TryGetValue("Immune", out immune);
			if ( !immune )
			{
				foreach ( var e in CurrentRoom.Exits[dir].Effects )
				{
					IEffect effect;
					StoogeWorld.Effects.TryGetValue(e, out effect);
					effect?.Apply(this);
				}
			}

			CurrentRoom = CurrentRoom.ParentArea.Rooms[CurrentRoom.Exits[dir].DestinationRoom];
		}
	}
}
