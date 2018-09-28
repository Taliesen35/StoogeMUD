using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using StoogeWorld.Things.Areas;
using StoogeWorld.Things.Effects;
using StoogeWorld.Things.Items;
using StoogeWorld.Utiltities;

namespace StoogeWorld.Things.Mobs.Players
{
	public class Player : Mobile
	{
		private const string PlayerDirectory = "../../data/players/";

		public PlayerState State { get; set; }
		public Socket Socket { get; set; }

		public Player()
		{
			State = PlayerState.Connected;
		}

		public Player(string name)
		{
			Name = name;
			Inventory = new List<Item>();
			Equipped = new List<Item>();
			Flags = new Dictionary<string, bool>();
		}


		public override bool Save()
		{
			var json = JsonConvert.SerializeObject(this, Formatting.Indented);
			File.WriteAllText($"{PlayerDirectory}{Name}.player", json);
			Console.WriteLine(json);

			return true;
		}

		public override IThing Load(string name)
		{
			using ( var r = new StreamReader(PlayerDirectory + name) )
			{
				var json = r.ReadToEnd();
				Console.WriteLine(json);
				var player = JsonConvert.DeserializeObject<Player>(json);
				player.CurrentRoom = StoogeWorld.Areas.Where(x => x.Rooms.ContainsKey(player.CurrentRoom.Id)).Select(x => x.Rooms[player.CurrentRoom.Id]).Single();
				return player;
			}
		}

		public override void Send(string message)
		{
			Socket.Send(Encoding.ASCII.GetBytes(message));
		}

	}

	public enum PlayerState
	{
		Connected,
		LoggingIn,
		LoggedIn,
		Playing,
		Creating,
		Created
	}
}
