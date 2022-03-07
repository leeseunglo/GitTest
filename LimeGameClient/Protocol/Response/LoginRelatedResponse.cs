using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public abstract class Response
	{
	}

	public class GetAuthnTokenResponse : Response
	{
		public string authnToken { get; set; }
		public string session { get; set; }
	}

	public class LoginWithTokenResponse : Response
	{
		public string mtalkToken { get; set; }
		public string characterId { get; set; }
		public long gameUserId { get; set; }
		public SubscriptionInfo subscriptionInfo { get; set; }

        // 아무것도 하지 않는다.
		public List<GameRoomInfo> gameRoomInfoList { get; set; }
	}

	public class LogoutWithTokenResponse : Response
	{
		public string message { get; set; }
	}
}
