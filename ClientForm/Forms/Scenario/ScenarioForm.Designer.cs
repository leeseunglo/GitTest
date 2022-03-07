
namespace ClientForm.Scenario
{
	partial class ScenarioForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cb_ActionList = new System.Windows.Forms.ComboBox();
			this.cb_LoginUserInfo = new System.Windows.Forms.ComboBox();
			this.b_ScenarioPush = new System.Windows.Forms.Button();
			this.gb_ScenarioController = new System.Windows.Forms.GroupBox();
			this.b_ScenarioStart = new System.Windows.Forms.Button();
			this.lv_ScenarioList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_NickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_ActionData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Req = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_Res = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.b_Reset = new System.Windows.Forms.Button();
			this.tb_TimeOut = new System.Windows.Forms.TextBox();
			this.TimeOut = new System.Windows.Forms.Label();
			this.is_TestMode = new System.Windows.Forms.CheckBox();
			this.b_OpenFile = new System.Windows.Forms.Button();
			this.Dialog_OpenScenarioFile = new System.Windows.Forms.OpenFileDialog();
			this.b_ScenarioFileWrite = new System.Windows.Forms.Button();
			this.Dialog_ScenarioFileWrite = new System.Windows.Forms.SaveFileDialog();
			this.gb_ScenarioController.SuspendLayout();
			this.SuspendLayout();
			// 
			// cb_ActionList
			// 
			this.cb_ActionList.FormattingEnabled = true;
			this.cb_ActionList.Location = new System.Drawing.Point(10, 45);
			this.cb_ActionList.Name = "cb_ActionList";
			this.cb_ActionList.Size = new System.Drawing.Size(243, 20);
			this.cb_ActionList.TabIndex = 0;
			// 
			// cb_LoginUserInfo
			// 
			this.cb_LoginUserInfo.FormattingEnabled = true;
			this.cb_LoginUserInfo.Location = new System.Drawing.Point(10, 19);
			this.cb_LoginUserInfo.Name = "cb_LoginUserInfo";
			this.cb_LoginUserInfo.Size = new System.Drawing.Size(243, 20);
			this.cb_LoginUserInfo.TabIndex = 1;
			// 
			// b_ScenarioPush
			// 
			this.b_ScenarioPush.Location = new System.Drawing.Point(258, 19);
			this.b_ScenarioPush.Name = "b_ScenarioPush";
			this.b_ScenarioPush.Size = new System.Drawing.Size(47, 46);
			this.b_ScenarioPush.TabIndex = 2;
			this.b_ScenarioPush.Text = "추가";
			this.b_ScenarioPush.UseVisualStyleBackColor = true;
			this.b_ScenarioPush.Click += new System.EventHandler(this.b_ScenarioPush_Click);
			// 
			// gb_ScenarioController
			// 
			this.gb_ScenarioController.Controls.Add(this.b_ScenarioPush);
			this.gb_ScenarioController.Controls.Add(this.cb_LoginUserInfo);
			this.gb_ScenarioController.Controls.Add(this.cb_ActionList);
			this.gb_ScenarioController.Location = new System.Drawing.Point(7, 10);
			this.gb_ScenarioController.Name = "gb_ScenarioController";
			this.gb_ScenarioController.Size = new System.Drawing.Size(313, 76);
			this.gb_ScenarioController.TabIndex = 3;
			this.gb_ScenarioController.TabStop = false;
			this.gb_ScenarioController.Text = "Scenario Controller";
			// 
			// b_ScenarioStart
			// 
			this.b_ScenarioStart.Location = new System.Drawing.Point(326, 17);
			this.b_ScenarioStart.Name = "b_ScenarioStart";
			this.b_ScenarioStart.Size = new System.Drawing.Size(78, 32);
			this.b_ScenarioStart.TabIndex = 3;
			this.b_ScenarioStart.Text = "시작";
			this.b_ScenarioStart.UseVisualStyleBackColor = true;
			this.b_ScenarioStart.Click += new System.EventHandler(this.b_ScenarioStart_Click);
			// 
			// lv_ScenarioList
			// 
			this.lv_ScenarioList.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.lv_ScenarioList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_ScenarioList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.col_Num,
            this.col_NickName,
            this.col_Action,
            this.col_ActionData,
            this.col_Req,
            this.col_Res});
			this.lv_ScenarioList.GridLines = true;
			this.lv_ScenarioList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv_ScenarioList.HideSelection = false;
			this.lv_ScenarioList.HoverSelection = true;
			this.lv_ScenarioList.Location = new System.Drawing.Point(7, 95);
			this.lv_ScenarioList.Name = "lv_ScenarioList";
			this.lv_ScenarioList.Size = new System.Drawing.Size(786, 345);
			this.lv_ScenarioList.TabIndex = 4;
			this.lv_ScenarioList.UseCompatibleStateImageBehavior = false;
			this.lv_ScenarioList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 3;
			// 
			// col_Num
			// 
			this.col_Num.Text = "";
			this.col_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col_Num.Width = 20;
			// 
			// col_NickName
			// 
			this.col_NickName.Text = "닉네임";
			this.col_NickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col_NickName.Width = 80;
			// 
			// col_Action
			// 
			this.col_Action.Text = "Action";
			this.col_Action.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col_Action.Width = 150;
			// 
			// col_ActionData
			// 
			this.col_ActionData.Text = "ActionData";
			this.col_ActionData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col_ActionData.Width = 390;
			// 
			// col_Req
			// 
			this.col_Req.Text = "Req";
			this.col_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// col_Res
			// 
			this.col_Res.Text = "Res";
			this.col_Res.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// b_Reset
			// 
			this.b_Reset.Location = new System.Drawing.Point(326, 52);
			this.b_Reset.Name = "b_Reset";
			this.b_Reset.Size = new System.Drawing.Size(78, 32);
			this.b_Reset.TabIndex = 5;
			this.b_Reset.Text = "초기화";
			this.b_Reset.UseVisualStyleBackColor = true;
			this.b_Reset.Click += new System.EventHandler(this.b_Reset_Click);
			// 
			// tb_TimeOut
			// 
			this.tb_TimeOut.Location = new System.Drawing.Point(733, 26);
			this.tb_TimeOut.Name = "tb_TimeOut";
			this.tb_TimeOut.Size = new System.Drawing.Size(57, 21);
			this.tb_TimeOut.TabIndex = 6;
			this.tb_TimeOut.Text = "5";
			this.tb_TimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// TimeOut
			// 
			this.TimeOut.AutoSize = true;
			this.TimeOut.Location = new System.Drawing.Point(662, 31);
			this.TimeOut.Name = "TimeOut";
			this.TimeOut.Size = new System.Drawing.Size(70, 12);
			this.TimeOut.TabIndex = 7;
			this.TimeOut.Text = "TimeOut(s)";
			// 
			// is_TestMode
			// 
			this.is_TestMode.AutoSize = true;
			this.is_TestMode.Location = new System.Drawing.Point(709, 4);
			this.is_TestMode.Name = "is_TestMode";
			this.is_TestMode.Size = new System.Drawing.Size(81, 16);
			this.is_TestMode.TabIndex = 15;
			this.is_TestMode.Text = "TestMode";
			this.is_TestMode.UseVisualStyleBackColor = true;
			// 
			// b_OpenFile
			// 
			this.b_OpenFile.Location = new System.Drawing.Point(408, 17);
			this.b_OpenFile.Name = "b_OpenFile";
			this.b_OpenFile.Size = new System.Drawing.Size(78, 32);
			this.b_OpenFile.TabIndex = 16;
			this.b_OpenFile.Text = "파일 열기";
			this.b_OpenFile.UseVisualStyleBackColor = true;
			this.b_OpenFile.Click += new System.EventHandler(this.b_OpenFile_Click);
			// 
			// b_ScenarioFileWrite
			// 
			this.b_ScenarioFileWrite.Location = new System.Drawing.Point(408, 52);
			this.b_ScenarioFileWrite.Name = "b_ScenarioFileWrite";
			this.b_ScenarioFileWrite.Size = new System.Drawing.Size(78, 32);
			this.b_ScenarioFileWrite.TabIndex = 17;
			this.b_ScenarioFileWrite.Text = "저장하기";
			this.b_ScenarioFileWrite.UseVisualStyleBackColor = true;
			this.b_ScenarioFileWrite.Click += new System.EventHandler(this.b_ScenarioFileWrite_Click);
			// 
			// Dialog_ScenarioFileWrite
			// 
			this.Dialog_ScenarioFileWrite.DefaultExt = "csv";
			this.Dialog_ScenarioFileWrite.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
			this.Dialog_ScenarioFileWrite.RestoreDirectory = true;
			this.Dialog_ScenarioFileWrite.Title = "Save CSV Files";
			// 
			// ScenarioForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 448);
			this.Controls.Add(this.b_ScenarioFileWrite);
			this.Controls.Add(this.b_OpenFile);
			this.Controls.Add(this.is_TestMode);
			this.Controls.Add(this.TimeOut);
			this.Controls.Add(this.tb_TimeOut);
			this.Controls.Add(this.b_Reset);
			this.Controls.Add(this.lv_ScenarioList);
			this.Controls.Add(this.b_ScenarioStart);
			this.Controls.Add(this.gb_ScenarioController);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ScenarioForm";
			this.Text = "ScenarioForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScenarioForm_FormClosing);
			this.gb_ScenarioController.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cb_ActionList;
		private System.Windows.Forms.ComboBox cb_LoginUserInfo;
		private System.Windows.Forms.Button b_ScenarioPush;
		private System.Windows.Forms.GroupBox gb_ScenarioController;
		private System.Windows.Forms.Button b_ScenarioStart;
		private System.Windows.Forms.ListView lv_ScenarioList;
		private System.Windows.Forms.ColumnHeader col_Num;
		private System.Windows.Forms.ColumnHeader col_NickName;
		private System.Windows.Forms.ColumnHeader col_Action;
		private System.Windows.Forms.ColumnHeader col_ActionData;
		private System.Windows.Forms.ColumnHeader col_Res;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button b_Reset;
		private System.Windows.Forms.TextBox tb_TimeOut;
		private System.Windows.Forms.Label TimeOut;
		private System.Windows.Forms.ColumnHeader col_Req;
		private System.Windows.Forms.CheckBox is_TestMode;
		private System.Windows.Forms.Button b_OpenFile;
		private System.Windows.Forms.OpenFileDialog Dialog_OpenScenarioFile;
		private System.Windows.Forms.Button b_ScenarioFileWrite;
		private System.Windows.Forms.SaveFileDialog Dialog_ScenarioFileWrite;
	}
}