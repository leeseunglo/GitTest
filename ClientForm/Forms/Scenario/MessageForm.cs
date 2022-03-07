using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientForm.Common;
using ClientProtocol.Protocol;

namespace ClientForm.Scenario
{
	public partial class MessageForm : Form
	{
		LimeGameScenarioClient m_scenarioClient = null;
		eScenarioType m_scenarioType = eScenarioType.SendMessage;

		public MessageForm(LimeGameScenarioClient scenarioClient,  eScenarioType scenarioType, JoinedGameRoomInfo joinedRoomInfo)
		{
			InitializeComponent();

			if (eScenarioType.SendMessage != scenarioType)
				b_AddMessage.Text = "수신 메세지 추가";

			Text = $"{Text} ({scenarioType})";
			m_scenarioClient = scenarioClient;
			m_scenarioType = scenarioType;

			Helper.SetController(ref cb_ChatGroup, "채팅 룸을 선택해 주세요.", joinedRoomInfo.GetGameRoomNames());
			// 0번의 경우 Title이라서 제외한다.
			/*
			for (var i = 1; i < cb_ChatGroup.Items.Count; ++i)
			{
				var roomKey = cb_ChatGroup.Items[i];
				if (false == joinedRoomInfo.IsExistJoinedUser(roomKey.ToString(), m_scenarioUser.GetUserKey()))
					continue;
			}
			*/
		}

		#region button event definition function
		private void b_AddMessage_Click(object sender, EventArgs e)
		{
			if (0 == cb_ChatGroup.SelectedIndex)
			{
				Helper.FocusHandle(cb_ChatGroup, "채팅 룸을 선택해 주세요.");
				return;
			}

			m_scenarioClient.SendMessage(m_scenarioType, cb_ChatGroup.Text, tb_Message.Text);
			Close();
		}

		private void b_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
	}
}
