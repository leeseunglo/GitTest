namespace ClientForm
{
    partial class MainForm_New
	{
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			this.b_Login = new System.Windows.Forms.Button();
			this.tb_LoginId = new System.Windows.Forms.TextBox();
			this.tb_Password = new System.Windows.Forms.TextBox();
			this.tb_CharacterID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.gb_LoginGroup = new System.Windows.Forms.GroupBox();
			this.tb_ServerKey = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_GameName = new System.Windows.Forms.TextBox();
			this.tb_ServerName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_NickName = new System.Windows.Forms.TextBox();
			this.cb_ClientType = new System.Windows.Forms.ComboBox();
			this.cb_LoginUserInfo = new System.Windows.Forms.ComboBox();
			this.tc_Chatting = new System.Windows.Forms.TabControl();
			this.b_UserManagement = new System.Windows.Forms.Button();
			this.gb_Event = new System.Windows.Forms.GroupBox();
			this.b_ScenarioTest = new System.Windows.Forms.Button();
			this.b_TestMode = new System.Windows.Forms.Button();
			this.gb_LoginGroup.SuspendLayout();
			this.gb_Event.SuspendLayout();
			this.SuspendLayout();
			// 
			// b_Login
			// 
			this.b_Login.Location = new System.Drawing.Point(318, 116);
			this.b_Login.Name = "b_Login";
			this.b_Login.Size = new System.Drawing.Size(71, 26);
			this.b_Login.TabIndex = 2;
			this.b_Login.Text = "로그인";
			this.b_Login.UseVisualStyleBackColor = true;
			this.b_Login.Click += new System.EventHandler(this.b_Login_Click);
			// 
			// tb_LoginId
			// 
			this.tb_LoginId.Enabled = false;
			this.tb_LoginId.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_LoginId.Location = new System.Drawing.Point(254, 17);
			this.tb_LoginId.Name = "tb_LoginId";
			this.tb_LoginId.Size = new System.Drawing.Size(135, 20);
			this.tb_LoginId.TabIndex = 3;
			this.tb_LoginId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tb_Password
			// 
			this.tb_Password.Enabled = false;
			this.tb_Password.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_Password.Location = new System.Drawing.Point(254, 41);
			this.tb_Password.Name = "tb_Password";
			this.tb_Password.Size = new System.Drawing.Size(135, 20);
			this.tb_Password.TabIndex = 4;
			this.tb_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tb_CharacterID
			// 
			this.tb_CharacterID.Enabled = false;
			this.tb_CharacterID.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_CharacterID.Location = new System.Drawing.Point(254, 65);
			this.tb_CharacterID.Name = "tb_CharacterID";
			this.tb_CharacterID.Size = new System.Drawing.Size(135, 20);
			this.tb_CharacterID.TabIndex = 5;
			this.tb_CharacterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 11);
			this.label1.TabIndex = 15;
			this.label1.Text = "서    버";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 11);
			this.label2.TabIndex = 16;
			this.label2.Text = "게    임";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(206, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 11);
			this.label3.TabIndex = 17;
			this.label3.Text = "아 이 디";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.Location = new System.Drawing.Point(199, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 11);
			this.label4.TabIndex = 18;
			this.label4.Text = "비밀 번호";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(199, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 11);
			this.label5.TabIndex = 19;
			this.label5.Text = "캐릭터 ID";
			// 
			// gb_LoginGroup
			// 
			this.gb_LoginGroup.Controls.Add(this.tb_ServerKey);
			this.gb_LoginGroup.Controls.Add(this.label6);
			this.gb_LoginGroup.Controls.Add(this.tb_GameName);
			this.gb_LoginGroup.Controls.Add(this.tb_ServerName);
			this.gb_LoginGroup.Controls.Add(this.label7);
			this.gb_LoginGroup.Controls.Add(this.tb_NickName);
			this.gb_LoginGroup.Controls.Add(this.label5);
			this.gb_LoginGroup.Controls.Add(this.label4);
			this.gb_LoginGroup.Controls.Add(this.cb_ClientType);
			this.gb_LoginGroup.Controls.Add(this.label3);
			this.gb_LoginGroup.Controls.Add(this.label2);
			this.gb_LoginGroup.Controls.Add(this.label1);
			this.gb_LoginGroup.Controls.Add(this.tb_CharacterID);
			this.gb_LoginGroup.Controls.Add(this.tb_Password);
			this.gb_LoginGroup.Controls.Add(this.tb_LoginId);
			this.gb_LoginGroup.Controls.Add(this.b_Login);
			this.gb_LoginGroup.Location = new System.Drawing.Point(12, 41);
			this.gb_LoginGroup.Name = "gb_LoginGroup";
			this.gb_LoginGroup.Size = new System.Drawing.Size(395, 149);
			this.gb_LoginGroup.TabIndex = 20;
			this.gb_LoginGroup.TabStop = false;
			this.gb_LoginGroup.Text = "Login";
			// 
			// tb_ServerKey
			// 
			this.tb_ServerKey.Enabled = false;
			this.tb_ServerKey.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_ServerKey.Location = new System.Drawing.Point(57, 65);
			this.tb_ServerKey.Name = "tb_ServerKey";
			this.tb_ServerKey.Size = new System.Drawing.Size(135, 20);
			this.tb_ServerKey.TabIndex = 26;
			this.tb_ServerKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label6.Location = new System.Drawing.Point(3, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 11);
			this.label6.TabIndex = 25;
			this.label6.Text = "서버 Key";
			// 
			// tb_GameName
			// 
			this.tb_GameName.Enabled = false;
			this.tb_GameName.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_GameName.Location = new System.Drawing.Point(57, 41);
			this.tb_GameName.Name = "tb_GameName";
			this.tb_GameName.Size = new System.Drawing.Size(135, 20);
			this.tb_GameName.TabIndex = 24;
			this.tb_GameName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tb_ServerName
			// 
			this.tb_ServerName.Enabled = false;
			this.tb_ServerName.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_ServerName.Location = new System.Drawing.Point(57, 17);
			this.tb_ServerName.Name = "tb_ServerName";
			this.tb_ServerName.Size = new System.Drawing.Size(135, 20);
			this.tb_ServerName.TabIndex = 23;
			this.tb_ServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label7.Location = new System.Drawing.Point(209, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 11);
			this.label7.TabIndex = 22;
			this.label7.Text = "이    름";
			// 
			// tb_NickName
			// 
			this.tb_NickName.Enabled = false;
			this.tb_NickName.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tb_NickName.Location = new System.Drawing.Point(254, 89);
			this.tb_NickName.Name = "tb_NickName";
			this.tb_NickName.Size = new System.Drawing.Size(135, 20);
			this.tb_NickName.TabIndex = 21;
			this.tb_NickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cb_ClientType
			// 
			this.cb_ClientType.FormattingEnabled = true;
			this.cb_ClientType.Location = new System.Drawing.Point(187, 118);
			this.cb_ClientType.Name = "cb_ClientType";
			this.cb_ClientType.Size = new System.Drawing.Size(129, 20);
			this.cb_ClientType.TabIndex = 20;
			// 
			// cb_LoginUserInfo
			// 
			this.cb_LoginUserInfo.FormattingEnabled = true;
			this.cb_LoginUserInfo.Location = new System.Drawing.Point(32, 14);
			this.cb_LoginUserInfo.Name = "cb_LoginUserInfo";
			this.cb_LoginUserInfo.Size = new System.Drawing.Size(272, 20);
			this.cb_LoginUserInfo.TabIndex = 23;
			this.cb_LoginUserInfo.SelectedIndexChanged += new System.EventHandler(this.cb_LoginUserInfo_SelectedIndexChanged);
			// 
			// tc_Chatting
			// 
			this.tc_Chatting.Location = new System.Drawing.Point(4, 377);
			this.tc_Chatting.Name = "tc_Chatting";
			this.tc_Chatting.SelectedIndex = 0;
			this.tc_Chatting.Size = new System.Drawing.Size(496, 99);
			this.tc_Chatting.TabIndex = 25;
			// 
			// b_UserManagement
			// 
			this.b_UserManagement.Location = new System.Drawing.Point(4, 81);
			this.b_UserManagement.Name = "b_UserManagement";
			this.b_UserManagement.Size = new System.Drawing.Size(73, 30);
			this.b_UserManagement.TabIndex = 3;
			this.b_UserManagement.Text = "유저 정보";
			this.b_UserManagement.UseVisualStyleBackColor = true;
			this.b_UserManagement.Click += new System.EventHandler(this.b_UserManagement_Click);
			// 
			// gb_Event
			// 
			this.gb_Event.Controls.Add(this.b_TestMode);
			this.gb_Event.Controls.Add(this.b_ScenarioTest);
			this.gb_Event.Controls.Add(this.b_UserManagement);
			this.gb_Event.Location = new System.Drawing.Point(413, 10);
			this.gb_Event.Name = "gb_Event";
			this.gb_Event.Size = new System.Drawing.Size(80, 180);
			this.gb_Event.TabIndex = 28;
			this.gb_Event.TabStop = false;
			this.gb_Event.Text = "Event";
			// 
			// b_ScenarioTest
			// 
			this.b_ScenarioTest.Location = new System.Drawing.Point(4, 50);
			this.b_ScenarioTest.Name = "b_ScenarioTest";
			this.b_ScenarioTest.Size = new System.Drawing.Size(73, 30);
			this.b_ScenarioTest.TabIndex = 4;
			this.b_ScenarioTest.Text = "시나리오";
			this.b_ScenarioTest.UseVisualStyleBackColor = true;
			this.b_ScenarioTest.Click += new System.EventHandler(this.b_ScenarioTest_Click);
			// 
			// b_TestMode
			// 
			this.b_TestMode.Location = new System.Drawing.Point(4, 19);
			this.b_TestMode.Name = "b_TestMode";
			this.b_TestMode.Size = new System.Drawing.Size(73, 30);
			this.b_TestMode.TabIndex = 5;
			this.b_TestMode.Text = "Test On";
			this.b_TestMode.UseVisualStyleBackColor = true;
			this.b_TestMode.Click += new System.EventHandler(this.b_TestMode_Click);
			// 
			// MainForm_New
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 479);
			this.Controls.Add(this.gb_Event);
			this.Controls.Add(this.tc_Chatting);
			this.Controls.Add(this.cb_LoginUserInfo);
			this.Controls.Add(this.gb_LoginGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm_New";
			this.Text = "RoyaChatting";
			this.gb_LoginGroup.ResumeLayout(false);
			this.gb_LoginGroup.PerformLayout();
			this.gb_Event.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Button b_Login;
		private System.Windows.Forms.TextBox tb_LoginId;
		private System.Windows.Forms.TextBox tb_Password;
		private System.Windows.Forms.TextBox tb_CharacterID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox gb_LoginGroup;
        private System.Windows.Forms.ComboBox cb_ClientType;
		private System.Windows.Forms.ComboBox cb_LoginUserInfo;
		private System.Windows.Forms.TabControl tc_Chatting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_NickName;
		private System.Windows.Forms.TextBox tb_GameName;
		private System.Windows.Forms.TextBox tb_ServerName;
		private System.Windows.Forms.TextBox tb_ServerKey;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button b_UserManagement;
		private System.Windows.Forms.GroupBox gb_Event;
		private System.Windows.Forms.Button b_ScenarioTest;
		private System.Windows.Forms.Button b_TestMode;
	}
}

