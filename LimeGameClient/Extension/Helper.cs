using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Protocol.Stomp;
using ClientProtocol.Protocol;

namespace ClientProtocol.Extension
{
	public static class Helper
	{
		public static string GetIgnoreMethod(string stompCommand)
		{
			if (StompCommand.CONNECTED == stompCommand || StompCommand.RECEIPT == stompCommand || StompCommand.SYSTEM == stompCommand)
				return CommandMap.SYSTEM_MESSAGE;

			return string.Empty;
		}
	}
}
