
namespace ClientForm
{
	partial class UserStatusForm
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
			this.cb_ReceiveOneOnOne = new System.Windows.Forms.CheckBox();
			this.b_Update = new System.Windows.Forms.Button();
			this.b_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cb_ReceiveOneOnOne
			// 
			this.cb_ReceiveOneOnOne.AutoSize = true;
			this.cb_ReceiveOneOnOne.Location = new System.Drawing.Point(19, 13);
			this.cb_ReceiveOneOnOne.Name = "cb_ReceiveOneOnOne";
			this.cb_ReceiveOneOnOne.Size = new System.Drawing.Size(96, 16);
			this.cb_ReceiveOneOnOne.TabIndex = 0;
			this.cb_ReceiveOneOnOne.Text = "1:1 채팅 수신";
			this.cb_ReceiveOneOnOne.UseVisualStyleBackColor = true;
			// 
			// b_Update
			// 
			this.b_Update.Location = new System.Drawing.Point(4, 41);
			this.b_Update.Name = "b_Update";
			this.b_Update.Size = new System.Drawing.Size(60, 30);
			this.b_Update.TabIndex = 1;
			this.b_Update.Text = "변 경";
			this.b_Update.UseVisualStyleBackColor = true;
			this.b_Update.Click += new System.EventHandler(this.b_Update_Click);
			// 
			// b_Cancel
			// 
			this.b_Cancel.Location = new System.Drawing.Point(68, 41);
			this.b_Cancel.Name = "b_Cancel";
			this.b_Cancel.Size = new System.Drawing.Size(60, 30);
			this.b_Cancel.TabIndex = 2;
			this.b_Cancel.Text = "취 소";
			this.b_Cancel.UseVisualStyleBackColor = true;
			this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
			// 
			// UserStatusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(133, 76);
			this.ControlBox = false;
			this.Controls.Add(this.b_Cancel);
			this.Controls.Add(this.b_Update);
			this.Controls.Add(this.cb_ReceiveOneOnOne);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "UserStatusForm";
			this.Text = "UserStatusForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cb_ReceiveOneOnOne;
		private System.Windows.Forms.Button b_Update;
		private System.Windows.Forms.Button b_Cancel;
	}
}