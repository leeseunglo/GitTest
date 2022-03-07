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
using Core;

namespace ClientForm
{
	public partial class ReportMessageForm : Form
	{
		private Dictionary<string, eGameReportReason> m_dicReportReason = new Dictionary<string, eGameReportReason>();
		private readonly IChatClient m_chatClient = null;
		private readonly MessageInfo m_reportMsgInfo = null;

		public ReportMessageForm(IChatClient chatClient, MessageInfo reportMsg)
		{
			m_chatClient = chatClient;
			m_reportMsgInfo = reportMsg;

			InitializeComponent();

			setFormData();
		}

		#region private function
		private void setFormData()
		{
			tb_UserName.Text = m_reportMsgInfo.UserName;
			tb_Message.Text = m_reportMsgInfo.Content;

			InitReportReasonComboBox();
		}

		private void InitReportReasonComboBox()
		{
			cb_Reason.Items.Clear();
			addReportReason("선택하시오", eGameReportReason.NONE);
			addReportReason("음 란", eGameReportReason.OBSCENE);
			addReportReason("욕 설", eGameReportReason.INSULT);
			addReportReason("도 배", eGameReportReason.PLASTER);
			addReportReason("광 고", eGameReportReason.ADVERTISE);

			Helper.SetComboBoxStyle(ref cb_Reason, 0);
			Helper.SetComboBoxTitle(cb_Reason);
		}

		private void addReportReason(string strName, eGameReportReason type)
		{
			m_dicReportReason.Add(strName, type);
			cb_Reason.Items.Add(strName);
		}
		#endregion

		#region form event
		private void b_Report_Click(object sender, EventArgs e)
		{
			if (null == cb_Reason.SelectedItem)
			{
				Log.ErrorLog("selected reason null");
				return;
			}

			eGameReportReason eReportReason = eGameReportReason.NONE;
			if (false == m_dicReportReason.TryGetValue(cb_Reason.SelectedItem.ToString(), out eReportReason) || eGameReportReason.NONE == eReportReason)
			{
				Log.ErrorLog($"reason enum fail. {cb_Reason.SelectedItem}");
				return;
			}

			m_chatClient.CreateReportMessage(m_reportMsgInfo, eReportReason);
			Close();
		}

		private void b_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cb_Reason_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (false == Helper.RemoveTitle(ref cb_Reason))
				return;

			b_Report.Enabled = true;
		}
		#endregion
	}
}
