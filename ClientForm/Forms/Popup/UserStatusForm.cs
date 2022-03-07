using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientForm.Client;
using ClientProtocol.Protocol;

namespace ClientForm
{
	public partial class UserStatusForm : Form
	{
		private readonly IChatClient m_chatClient = null;

		public UserStatusForm(IChatClient chatClient)
		{
			InitializeComponent();

			m_chatClient = chatClient;
			SetFormData();
		}

		#region private function
		private void SetFormData()
		{
			cb_ReceiveOneOnOne.Checked = true;
		}
		#endregion

		#region form event definition function
		private void b_Update_Click(object sender, EventArgs e)
		{
			var req = new UpdateCharcharacterStatusRequest();
			req.characterStatusInfo = new CharacterStatusInfo()
			{
				receiveOneOnOne = cb_ReceiveOneOnOne.Checked
			};

			m_chatClient.SendMessage(req);
			Close();
		}

		private void b_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion
	}
}
