using System.Net;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace StoogeServer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var server = new StoogeServer(IPAddress.Parse("127.0.0.1"), 4001);
			server.Run(null);
		}
	}
}
