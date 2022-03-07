using System;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Client;
using ClientProtocol.Protocol;
using Core;

namespace ClientForm
{
	public partial class PrivateChatForm : Form
	{
		const string Whisper = "귓속말";
		const string OneOnOne = "1:1 대화";

		private readonly LimeGameUserKey m_limeGameUserKey = null;
		private readonly IChatClient m_chatClient = null;

		private Action<string, eSendMessageType, bool> m_actionUpdateMsgType = null;
		public PrivateChatForm(IChatClient chatClient, Action<string, eSendMessageType, bool> actionMsgType, string nickName = "")
		{
			switch (chatClient.GetClientType())
			{
				case eClientType.LimeGame:
					m_limeGameUserKey = (chatClient as LimeGameClient)?.GetGameUserKey();
					break;
			}

			if (null == m_limeGameUserKey)
			{
				Log.ErrorLog("ChatGroupForm. set game room key fail.");
				Close();
			}

			InitializeComponent();

			m_chatClient = chatClient;
			m_actionUpdateMsgType = actionMsgType;
			tb_NickName.Text = nickName;

			SetFormData();
		}

		#region private function
		private void SetFormData()
		{
			Helper.SetController(ref cb_RoomType, string.Empty, new string[] { Whisper, OneOnOne });
		}
		#endregion

		#region form event definition function
		private void b_Create_Click(object sender, EventArgs e)
		{
			string nickName = tb_NickName.Text;
			if (true == string.IsNullOrEmpty(nickName))
			{
				Helper.FocusHandle(tb_NickName, "닉네임을 적어주세요.");
				return;
			}

			if (true == nickName.Equals(m_chatClient.UserInfo.NickName))
			{
				Helper.FocusHandle(tb_NickName, "자기 자신과는 채팅을 할수 없습니다.");
				return;
			}

			var userKey = m_limeGameUserKey.GetGetUserKey(nickName);
			if (null == userKey)
			{
				Log.ErrorLog($"PrivateChatForm. not found user key. NickName:{nickName}");
			}
			else
			{
				string strChatType = cb_RoomType.SelectedItem.ToString();
				switch (strChatType)
				{
					case Whisper:
						m_actionUpdateMsgType?.Invoke(nickName, eSendMessageType.Whisper, false);
						break;

					case OneOnOne:
						m_chatClient.SendMessage(new CreateOneOnOneRoomWithUserRequest() { gameUserKey = userKey });
						break;
				}
			}

			Close();
		}

		private void b_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
	}
}
