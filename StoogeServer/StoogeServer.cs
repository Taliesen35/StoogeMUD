using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using StoogeWorld.Things.Mobs.Players;

namespace StoogeServer
{
	public class StoogeServer
	{
		private readonly int _port;
		private readonly IPAddress _localAddress;

		public TcpListener Server { get; set; }
		public StoogeWorld.StoogeWorld World { get; set; }

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

			World.Load();
			
			Console.WriteLine($"Server listening at {_localAddress}:{_port}");

			while ( true )
			{
				var socket = Server.AcceptSocket();
				Console.WriteLine("Connection accepted...");
				var player = new Player{Socket = socket};
				

				//Handle Ticks
				_lastPulse = World.Pulse(_lastPulse);

				//Handle World Resets

				//Main Mud Loop

			}
		}
	}
}
