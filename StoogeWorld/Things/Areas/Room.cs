using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StoogeWorld.Utiltities;

namespace StoogeWorld.Things.Areas
{
	public class Room : Thing
	{
		public int ParentAreaId { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public TerrainType Terrain { get; set; }
		public Dictionary<string, bool> Flags { get; set; }
		public Dictionary<Direction, Exit> Exits { get; set; }
		public Area ParentArea { get; set; }

		public override bool Save()
		{
			return false;
		}
		public override IThing Load(string name)
		{
			return new Room();
		}
	}

	public enum TerrainType
	{
		inside
		,arctic
		,field
		,forest
		,hills
		,mountain
		,desert
		,underground_city
		,glacier
		,tundra
		,jungle
		,lava
		,ocean
		,river
		,cave
	}
}
