using System;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Config;
using Core;

namespace ClientForm
{
    public partial class GameCodeForm : Form
    {
        private Action m_actionResetComboBox = null;

        public GameCodeForm(Action resetComboBox)
        {
            InitializeComponent();

            InitFormData();

            m_actionResetComboBox = resetComboBox;
        }

        #region private function
        private void InitFormData()
        {
            InitComboBox();
        }

        private void InitComboBox(bool resetTopForm = false)
		{
            Helper.SetController(ref cb_GameCodeList, "게임 코드", ConfigData.INST.GameCodeMgr.GetKeys());
            if (true == resetTopForm)
                m_actionResetComboBox?.Invoke();
        }

        private void InitTextBox()
		{
            tb_GameName.Clear();
            tb_GameCode.Clear();
        }

        #region button event definition function
        private void b_Add_Click(object sender, EventArgs e)
        {
            string gameName = tb_GameName.Text.ToString();
            if (string.IsNullOrEmpty(gameName))
            {
                Helper.FocusHandle(tb_GameName, "게임 이름을 적어주세요.");
                return;
            }

            string gameCode = tb_GameCode.Text.ToString();
            if (string.IsNullOrEmpty(gameCode))
            {
                Helper.FocusHandle(tb_GameName, "게임 코드를 적어주세요.");
                return;
            }

            InitTextBox();
            ConfigData.INST.GameCodeMgr.AddInfo(new GameCodeInfo(gameName, gameCode));
            if (true == cb_GameCodeList.Items.Contains(gameName))
                return;

            InitComboBox(true);
        }

        private void b_Remove_Click(object sender, EventArgs e)
        {
            try
			{
                string strKey = tb_GameName.Text;
                if (string.IsNullOrEmpty(strKey))
                    throw new Exception("remove key null");

                if (false == ConfigData.INST.GameCodeMgr.Remove(strKey))
                    throw new Exception($"not found key. {strKey}");

                InitTextBox();
                InitComboBox(true);
            }
            catch (Exception ex)
			{
                Log.ErrorLog($"ServerInfoForm. remove event fail. {ex.Message}");
            }
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
		#endregion

		private void cb_ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == cb_GameCodeList.SelectedIndex)
                return;

            string strKey = cb_GameCodeList.SelectedItem.ToString();
            GameCodeInfo info = ConfigData.INST.GameCodeMgr.Get(strKey);
            if (null == info)
                return;

            tb_GameName.Text = info.Name;
            tb_GameCode.Text = info.Code;
        }
        #endregion
    }
}
