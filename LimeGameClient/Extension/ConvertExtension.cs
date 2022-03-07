using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using ClientProtocol.Model;

namespace ClientProtocol.Extension
{
	public static class ConvertExtension
	{
		public static StompInfo ToStompInfo(this SubscriptionInfo from)
		{
			return new StompInfo(from);
		}
	}
}
