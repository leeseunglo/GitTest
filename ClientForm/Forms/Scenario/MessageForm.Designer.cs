
namespace ClientForm.Scenario
{
	partial class MessageForm
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
			this.cb_ChatGroup = new System.Windows.Forms.ComboBox();
			this.tb_Message = new System.Windows.Forms.TextBox();
			this.b_AddMessage = new System.Windows.Forms.Button();
			this.b_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cb_ChatGroup
			// 
			this.cb_ChatGroup.FormattingEnabled = true;
			this.cb_ChatGroup.Location = new System.Drawing.Point(8, 9);
			this.cb_ChatGroup.Name = "cb_ChatGroup";
			this.cb_ChatGroup.Size = new System.Drawing.Size(336, 20);
			this.cb_ChatGroup.TabIndex = 0;
			// 
			// tb_Message
			// 
			this.tb_Message.Location = new System.Drawing.Point(8, 35);
			this.tb_Message.Name = "tb_Message";
			this.tb_Message.Size = new System.Drawing.Size(336, 21);
			this.tb_Message.TabIndex = 1;
			this.tb_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// b_AddMessage
			// 
			this.b_AddMessage.Location = new System.Drawing.Point(160, 62);
			this.b_AddMessage.Name = "b_AddMessage";
			this.b_AddMessage.Size = new System.Drawing.Size(114, 30);
			this.b_AddMessage.TabIndex = 2;
			this.b_AddMessage.Text = "발신 메세지 추가";
			this.b_AddMessage.UseVisualStyleBackColor = true;
			this.b_AddMessage.Click += new System.EventHandler(this.b_AddMessage_Click);
			// 
			// b_Cancel
			// 
			this.b_Cancel.Location = new System.Drawing.Point(275, 62);
			this.b_Cancel.Name = "b_Cancel";
			this.b_Cancel.Size = new System.Drawing.Size(69, 30);
			this.b_Cancel.TabIndex = 3;
			this.b_Cancel.Text = "취소";
			this.b_Cancel.UseVisualStyleBackColor = true;
			this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
			// 
			// MessageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 98);
			this.ControlBox = false;
			this.Controls.Add(this.b_Cancel);
			this.Controls.Add(this.b_AddMessage);
			this.Controls.Add(this.tb_Message);
			this.Controls.Add(this.cb_ChatGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MessageForm";
			this.Text = "MessageForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cb_ChatGroup;
		private System.Windows.Forms.TextBox tb_Message;
		private System.Windows.Forms.Button b_AddMessage;
		private System.Windows.Forms.Button b_Cancel;
	}
}