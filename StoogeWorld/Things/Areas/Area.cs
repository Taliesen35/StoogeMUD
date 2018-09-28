using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StoogeWorld.Things.Items;
using StoogeWorld.Things.Mobs.NPCs;

namespace StoogeWorld.Things.Areas
{
	public class Area : Thing
	{
		private const string AreaDirectory = "../../data/areas/";

		[JsonProperty(Order = 4)]
		public Dictionary<int, Room> Rooms { get; set;	}
		[JsonProperty(Order = 5)]
		public Dictionary<string, Npc> Npcs { get; set; }
		[JsonProperty(Order = 6)]
		public Dictionary<int, Item> Items { get; set; }
		//public Dictionary<string, Reset> Resets = null;

		public Area(string name)
		{
			Name = name;
			Rooms = new Dictionary<int, Room>();
			Items = new Dictionary<int, Item>();
			Npcs = new Dictionary<string, Npc>();
		}

		public override bool Save()
		{
			var json = JsonConvert.SerializeObject(this, Formatting.Indented);
			File.WriteAllText($"{AreaDirectory}{Name}.area", json);
			Console.WriteLine(json);

			return false;
		}
		public override IThing Load(string name)
		{
			using ( var r = new StreamReader(AreaDirectory + name) )
			{
				var json = r.ReadToEnd();
				var area = JsonConvert.DeserializeObject<Area>(json);
				return area;
			}
		}
	}
}
