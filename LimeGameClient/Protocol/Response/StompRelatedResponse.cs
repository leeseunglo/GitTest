using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol	
{
	public class StompResponse
	{
		public string tid { get; set; }
		public string type { get; set; }
		public string method { get; set; }
		public object jsonData { get; set; }
		public string dateRequest { get; set; }
	}
}
