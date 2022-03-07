
namespace ClientForm
{
	partial class ReportMessageForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_UserName = new System.Windows.Forms.TextBox();
			this.tb_Message = new System.Windows.Forms.TextBox();
			this.b_Cancel = new System.Windows.Forms.Button();
			this.b_Report = new System.Windows.Forms.Button();
			this.cb_Reason = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "신고 대상";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "신고 내용";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "신고 사유";
			// 
			// tb_UserName
			// 
			this.tb_UserName.Location = new System.Drawing.Point(11, 24);
			this.tb_UserName.Name = "tb_UserName";
			this.tb_UserName.ReadOnly = true;
			this.tb_UserName.Size = new System.Drawing.Size(185, 21);
			this.tb_UserName.TabIndex = 3;
			// 
			// tb_Message
			// 
			this.tb_Message.Location = new System.Drawing.Point(11, 69);
			this.tb_Message.Multiline = true;
			this.tb_Message.Name = "tb_Message";
			this.tb_Message.ReadOnly = true;
			this.tb_Message.Size = new System.Drawing.Size(185, 57);
			this.tb_Message.TabIndex = 4;
			// 
			// b_Cancel
			// 
			this.b_Cancel.Location = new System.Drawing.Point(107, 180);
			this.b_Cancel.Name = "b_Cancel";
			this.b_Cancel.Size = new System.Drawing.Size(92, 28);
			this.b_Cancel.TabIndex = 5;
			this.b_Cancel.Text = "취 소";
			this.b_Cancel.UseVisualStyleBackColor = true;
			this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
			// 
			// b_Report
			// 
			this.b_Report.Enabled = false;
			this.b_Report.Location = new System.Drawing.Point(9, 180);
			this.b_Report.Name = "b_Report";
			this.b_Report.Size = new System.Drawing.Size(92, 28);
			this.b_Report.TabIndex = 6;
			this.b_Report.Text = "신 고";
			this.b_Report.UseVisualStyleBackColor = true;
			this.b_Report.Click += new System.EventHandler(this.b_Report_Click);
			// 
			// cb_Reason
			// 
			this.cb_Reason.FormattingEnabled = true;
			this.cb_Reason.Location = new System.Drawing.Point(11, 150);
			this.cb_Reason.Name = "cb_Reason";
			this.cb_Reason.Size = new System.Drawing.Size(185, 20);
			this.cb_Reason.TabIndex = 7;
			this.cb_Reason.SelectedIndexChanged += new System.EventHandler(this.cb_Reason_SelectedIndexChanged);
			// 
			// ReportMessageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(207, 217);
			this.ControlBox = false;
			this.Controls.Add(this.cb_Reason);
			this.Controls.Add(this.b_Report);
			this.Controls.Add(this.b_Cancel);
			this.Controls.Add(this.tb_Message);
			this.Controls.Add(this.tb_UserName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ReportMessageForm";
			this.Text = "신고하기";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_UserName;
		private System.Windows.Forms.TextBox tb_Message;
		private System.Windows.Forms.Button b_Cancel;
		private System.Windows.Forms.Button b_Report;
		private System.Windows.Forms.ComboBox cb_Reason;
	}
}