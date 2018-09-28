using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stooge.Server;
using System.Net;

namespace Stooge
{
	class Program
	{
		static void Main(string[] args)
		{
			StoogeServer server = new StoogeServer(IPAddress.Parse("127.0.0.1"), 4001);
			server.Run(null);
		}
	}
}
