using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public abstract class Request
	{
	}

	public class GetAuthnTokenRequest : Request
	{
		public string username { get; set; }
		public string password { get; set; }
		public string clientType { get; set; }
		public string gameCode { get; set; }
		public string deviceId { get; set; }
	}

	public class LoginWithTokenRequest : Request
	{
		public string gameCode { get; set; }
		public string characterId { get; set; }
		public string serverKey { get; set; }
		public string deviceId { get; set; }
		public string clientType { get; set; }
		public string authnToken { get; set; }
	}

	public class LogoutWithTokenRequest : Request
	{

	}
}
