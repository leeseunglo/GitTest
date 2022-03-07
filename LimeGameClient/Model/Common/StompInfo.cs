using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;

namespace ClientProtocol.Model
{
	// STOMP 소켓 연결을 위한 접속 및 구독해야할 Topic 들에 대한 정보
	public partial class StompInfo
	{
		// 서버에서 발생하는 Event, Message 수신을 위해 구독해야할 Topic
		public string TopicName { get; private set; }

		// STOMP 접속용 URL
		public string SubscribeURL { get; private set; }

		// STOMP 접속용 1회용 ID
		public string Login { get; private set; }

		// STOMP 접속용 1회용 Password
		public string PassCode { get; private set; }

		// 전체 채팅(WORLD)를 사용하는 경우, 추가로 구독해야할 Topic
		public string WorldTopic { get; private set; }

		// STOMP 접속 후 API를 전송할 서버 어플리케이션 Destination
		public string ServerAppDest { get; private set; }
	}

	public partial class StompInfo
	{
		public StompInfo(SubscriptionInfo from)
		{
			TopicName = from.topicName;
			SubscribeURL = from.subscribeUrl;
			Login = from.login;
			PassCode = from.passcode;
			WorldTopic = from.worldTopic;
			ServerAppDest = from.serverAppDest;
		}
	}
}
