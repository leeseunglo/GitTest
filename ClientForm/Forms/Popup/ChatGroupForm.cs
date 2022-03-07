using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Client;
using ClientProtocol.Protocol;
using Core;

namespace ClientForm
{
	public partial class ChatGroupForm : Form
	{
		private readonly LimeGameRoomKey m_limeGameRoomKey = null;
		private readonly IChatClient m_chatClient = null;
		public ChatGroupForm(IChatClient chatClient)
		{
			switch (chatClient.GetClientType())
			{
				case eClientType.LimeGame:
					m_limeGameRoomKey = (chatClient as LimeGameClient)?.GetGameRoomKey();
					break;
			}

			if (null == m_limeGameRoomKey)
			{
				Log.ErrorLog("ChatGroupForm. set game room key fail.");
				Close();
			}

			m_chatClient = chatClient;
			InitializeComponent();
			SetFormData();

			if (true == Helper.TestDataSetting)
			{
				cb_RoomType.SelectedIndex = 1;
			}
		}


		#region private function
		private void SetFormData()
		{
			Helper.SetController(ref cb_RoomType, "Room Type", Enum.GetNames(typeof(eGameRoomType)));

			if (m_limeGameRoomKey.GetCount() > 0)
			{
				cb_JoinedRoom.Enabled = true;
				Helper.SetController(ref cb_JoinedRoom, "Joined Room", m_limeGameRoomKey.GetGameRoomNames());
			}
		}

		private void SendMessage(Request req)
		{
			m_chatClient.SendMessage(req);
		}
		#endregion

		private GameRoomKeyInfo CreateGameRoomKeyInfo()
		{
			if (true == Helper.ContainsTitle(cb_RoomType))
			{
				Helper.FocusHandle(cb_RoomType, "생성 할려는 방 타입을 선택해주세요.");
				return null;
			}

			if (string.IsNullOrEmpty(tb_ServerKey.Text))
			{
				Helper.FocusHandle(tb_ServerKey, "생성 할려는 서버의 Key를 적어주세요");
				return null;
			}

			if (string.IsNullOrEmpty(tb_RoomKey.Text))
			{
				Helper.FocusHandle(tb_ServerKey, "생성 할려는 방의 Key를 적어주세요.");
				return null;
			}

			return new GameRoomKeyInfo(cb_RoomType.SelectedItem.ToString(), tb_ServerKey.Text, tb_RoomKey.Text);
		}

		#region button event definition function
		private void b_Create_Click(object sender, EventArgs e)
		{
			var roomKeyInfo = CreateGameRoomKeyInfo();
			if (null == roomKeyInfo)
				return;

			Close();
			SendMessage(new CreateRoomRequest() { gameRoomKeyInfo = roomKeyInfo });
		}

		private void b_Join_Click(object sender, EventArgs e)
		{
			var roomKeyInfo = CreateGameRoomKeyInfo();
			if (null == roomKeyInfo)
				return;

			Close();
			SendMessage(new JoinRoomRequest() { gameRoomKeyInfo = roomKeyInfo });
		}

		private void b_Leave_Click(object sender, EventArgs e)
		{
			var roomKeyInfo = CreateGameRoomKeyInfo();
			if (null == roomKeyInfo)
				return;

			if (false == m_limeGameRoomKey.ContainsKey(roomKeyInfo))
			{
				Helper.FocusHandle(null, $"나갈려고 하는 방의 Key가 없습니다. KeyInfo:{roomKeyInfo.GetInfo()}");
				return;
			}

			Close();
			SendMessage(new LeaveRoomRequest() { gameRoomKeyInfo = roomKeyInfo });
		}

		private void b_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion

		private void cb_RoomType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Helper.RemoveTitle(ref cb_RoomType);
		}

		private void cb_JoinRoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (0 == cb_JoinedRoom.SelectedIndex)
				return;

			string roomName = cb_JoinedRoom.SelectedItem.ToString();
			var keyInfo = m_limeGameRoomKey.GetGameRoomKeyInfo(roomName);
			if (null == keyInfo)
				return;

			cb_RoomType.SelectedItem = keyInfo.type;
			tb_RoomKey.Text = keyInfo.roomKey;
			tb_ServerKey.Text = keyInfo.serverKey;

			Helper.RemoveTitle(ref cb_JoinedRoom);
		}
	}
}
