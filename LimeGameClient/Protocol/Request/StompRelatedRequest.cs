using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class StompRequest
	{
		public string tid { get; set; }
		public string method { get; set; }
		public object @params { get; set; }
	}
}
