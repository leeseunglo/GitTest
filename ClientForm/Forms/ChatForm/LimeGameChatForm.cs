using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using ClientForm.Client;
using ClientForm.Common;
using ClientProtocol.Protocol;

namespace ClientForm
{
	public enum eSendMessageType
	{
		None,
		Message,
		Whisper
	}

	public partial class LimeGameChatForm : Form
	{
		const string CHAT_BOX_DISPLAY = "Content";
		const string CHAT_BOX_DETAIL = "Detail";
		const string MESSAGE_TYPE_DISPLAY = "Name";
		const string MESSAGE_TYPE_VALUE = "Type";

		private IChatClient m_chatClient = null;
		private DataTable m_dtChatList = new DataTable();
		private DataTable m_dtMessageType = new DataTable();

		public LimeGameChatForm(IChatClient chatClient)
		{
			if (null == chatClient || null == chatClient.UserInfo)
			{
				Log.ErrorLog("game user null");
				return;
			}

			InitializeComponent();

			m_chatClient = chatClient;
			label_NickName.Text = chatClient.UserInfo.NickName;

			{
				SetListControl();
			}
		}

		#region set data table
		private void SetListControl()
		{
			Helper.SetListControlKeyValueData(lb_textBox, m_dtChatList, new List<DataColumn>()
			{
				new DataColumn(CHAT_BOX_DISPLAY, typeof(string)),
				new DataColumn(CHAT_BOX_DETAIL, typeof(MessageInfo))
			});

			Helper.SetListControlKeyValueData(cb_MessageType, m_dtMessageType, new List<DataColumn>()
			{
				new DataColumn(MESSAGE_TYPE_DISPLAY, typeof(string)),
				new DataColumn(MESSAGE_TYPE_VALUE, typeof(eSendMessageType))
			});
		}

		private void EnableMessageRelatedButton()
		{
			if (m_dtChatList.Rows.Count > 0)
				return;

			b_Report.Enabled = true;
			//b_Block.Enabled = true;
		}
		#endregion

		private MessageInfo GetMessageInfo()
		{
			MessageInfo msgInfo = null;
			try
			{
				if (null == lb_textBox.SelectedItem)
					throw new Exception("No text was selected");

				var rowData = lb_textBox.SelectedItem as DataRowView;
				if (null == rowData)
					throw new Exception("select text box fail");

				msgInfo = rowData[CHAT_BOX_DETAIL] as MessageInfo;
				if (null == msgInfo)
					throw new Exception("message info fail");
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"GetMessageInfo fail. Msg:{ex.Message}");
			}

			return msgInfo;
		}

		#region external form event
		public void OnLogout()
		{

		}

		public void OnUpdateMessageType(string strName, eSendMessageType eType, bool isDel)
		{
			Helper.ControlUpdate(cb_MessageType, () =>
			{
				try
				{
					DataRow row = Helper.GetDataRow(m_dtMessageType, strName);
					if (isDel)
					{
						if (null == row)
							throw new Exception("not found message type");

						m_dtMessageType.Rows.Remove(row);
					}
					else
					{
						if (null != row)
							throw new Exception($"already exists key");

						Helper.InsertDateRow(m_dtMessageType, strName, eType);
					}

					tb_SendMsg.Enabled = cb_MessageType.Enabled = cb_MessageType.Items.Count > 0;
				}
				catch (Exception ex)
				{
					Log.ErrorLog($"$UpdateMessageType fail. Msg:{ex.Message}, Key:{strName}");
				}
			});
		}

		public void OnDisplayMessage(string roomName, MessageInfo msgInfo)
		{
			Helper.ControlUpdate(lb_textBox, () =>
			{
				// 신고, 차단, 귓속말 관련 버튼 활성화 시킨다.
				EnableMessageRelatedButton();

				// Message display
				string strKey = $"[{roomName}][{msgInfo.UserName}] {msgInfo.Content}";
				Helper.InsertDateRow(m_dtChatList, strKey, msgInfo);
			});
		}
		#endregion

		#region form event definition function
		private void b_OpenChatGroupForm_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new ChatGroupForm(m_chatClient));
		}

		private void tb_SendMsg_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode != Keys.Enter || string.IsNullOrEmpty(tb_SendMsg.Text))
					return;

				var rowData = cb_MessageType.SelectedItem as DataRowView;
				if (null == rowData)
					throw new Exception("select row data as fail");

				eSendMessageType msgType = eSendMessageType.None;
				if (false == Enum.TryParse(rowData[MESSAGE_TYPE_VALUE].ToString(), out msgType))
					throw new Exception($"send message type fail. Type:{rowData[MESSAGE_TYPE_VALUE]}");

				if (eSendMessageType.Message == msgType)
					m_chatClient.SendTalk(cb_MessageType.Text, tb_SendMsg.Text);
				else
					m_chatClient.SendWhisper(cb_MessageType.Text, tb_SendMsg.Text);

				tb_SendMsg.Clear();
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"send message key down faul. exception Msg:{ex.Message}");
			}
		}

		private void b_Logout_Click(object sender, EventArgs e)
		{
			m_chatClient.Logout();
		}

		private void b_Report_Click(object sender, EventArgs e)
		{
			try
			{
				var msgInfo = GetMessageInfo();
				Helper.OpenForm(new ReportMessageForm(m_chatClient, msgInfo));
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"report message popup open fail. exception Msg:{ex.Message}");
			}
		}

		private void b_JoinedRoom_Click(object sender, EventArgs e)
		{
			m_chatClient.SendMessage(new GetJoinedRoomListRequest());
		}

		private void b_OpenPrivateChatForm_Click(object sender, EventArgs e)
		{
			try
			{
				string userName = "";
				var msgInfo = GetMessageInfo();
				if (null != msgInfo)
					userName = msgInfo.UserName;

				Helper.OpenForm(new PrivateChatForm(m_chatClient, OnUpdateMessageType, userName));
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"whisper fail. exception Msg:{ex.Message}");
			}
		}

		private void b_UserStatus_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new UserStatusForm(m_chatClient));
		}
		#endregion
	}
}
