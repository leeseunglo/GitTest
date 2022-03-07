using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientProtocol.Protocol;
using ClientForm.Common;
using ClientForm.Config;

namespace ClientForm.Client
{
	public interface IChatClient
	{
		LoginUserInfo UserInfo { get; }

		eClientType GetClientType();
		void Initialize(bool isTestMode);
		string GetUserKey();
		void SetActions(IMainForm mainForm, Form form);
		
		#region request method
		Task<bool> Login(string serverURL);
		void Logout();
		void SendMessage(Request request);
		void SendTalk(string strType, string strMsg);
		void SendWhisper(string strNickName, string strMsg);
		void CreateReportMessage(MessageInfo msgInfo, eGameReportReason eReason);
		#endregion

		/*
		void CreateRoom();
		void JoinRoom();
		void SendMessage();
		*/
	}

	public class GameUserFactory
	{
		public static IChatClient CreateChatClient(eClientType eType, LoginUserInfo userInfo)
		{
			switch (eType)
			{
				case eClientType.LimeGame:
					return new LimeGameClient(userInfo);
			}

			return null;
		}
	}
}
