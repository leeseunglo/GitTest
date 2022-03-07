using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class SubscriptionInfo
	{
		public string topicName { get; set; }
		public string subscribeUrl { get; set; }
		public string login { get; set; }
		public string passcode { get; set; }
		public string serverAppDest { get; set; }
		public string worldTopic { get; set; }
	}
}
