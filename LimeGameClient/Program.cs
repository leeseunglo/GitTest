using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientProtocol.Model;
using ClientProtocol.Protocol;
using Core.Protocol.Http;

namespace ClientProtocol
{
    class Program
    {
        static void Main(string[] args)
        {
			Task.Run(CreateRoomTest);
		}

		public static async Task CreateRoomTest()
		{
			var clientProxy = new LimeClientProxy();
			await clientProxy.Login("http://localhost:9180", "lime003@lime.com", "aaaa1111", "l2m", "1", "281474976711580").ConfigureAwait(false);
			clientProxy.Connect();

			for (var i = 0; i < 5; ++i)
				Thread.Sleep(1000);

			var createRoom = new CreateRoomRequest()
			{
				gameRoomKeyInfo = new GameRoomKeyInfo()
				{
					type = "REGION",
					serverKey = "server2",
					roomKey = "region-k1"
				}
			};

			clientProxy.SendMessage(createRoom);

			for (var i = 0; i < 5; ++i)
				Thread.Sleep(1000);
		}
	}
}
