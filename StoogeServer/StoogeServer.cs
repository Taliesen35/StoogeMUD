using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using StoogeWorld.Things.Mobs.Players;

namespace StoogeServer
{
	public class StoogeServer
	{
		private readonly int _port;
		private readonly IPAddress _localAddress;

		private TcpListener Server { get; set; }
		private StoogeWorld.StoogeWorld World { get; set; }

		private DateTime _lastPulse;

		public StoogeServer(IPAddress localAddress, int port)
		{
			_localAddress = localAddress;
			_port = port;
			_lastPulse = DateTime.Now;

			World = new StoogeWorld.StoogeWorld();
			Server = new TcpListener(_localAddress, port);
		}

		public void Run(string[] args)
		{
			Server.Start();

			var bytes = new byte[256];

			StoogeWorld.StoogeWorld.Load();

			Console.WriteLine($"Server listening at {_localAddress}:{_port}");

			while (true)
			{
				var client = Server.AcceptTcpClient();

				Console.WriteLine("Connection accepted...");

				var stream = client.GetStream();
				var p = new Player(stream);

				int i;

				//Main Mud Loop
				while ((i = p.Read(bytes, 0, bytes.Length)) != 0)
				{
					// Translate data bytes to a ASCII string.
					var data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
					Console.WriteLine("Received: {0}", data);

					// Process the data sent by the client.
					data = data.ToUpper();

					var msg = System.Text.Encoding.ASCII.GetBytes(data);

					// Send back a response.
					stream.Write(msg, 0, msg.Length);
					Console.WriteLine("Sent: {0}", data);
				}

				//Handle Ticks
				_lastPulse = World.Pulse(_lastPulse);

				//Handle World Resets
			}
		}
	}
}
