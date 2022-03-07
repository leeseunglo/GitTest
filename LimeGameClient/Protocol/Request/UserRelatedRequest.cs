using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class UpdateCharcharacterStatusRequest : Request
	{
		public CharacterStatusInfo characterStatusInfo { get; set; }
	}
}
