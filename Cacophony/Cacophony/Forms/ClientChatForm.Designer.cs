namespace Cacophony.Forms
{
    partial class ClientChatForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientChatForm));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tlpChatLog = new System.Windows.Forms.TableLayoutPanel();
            this.MessageTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnnouncements = new System.Windows.Forms.TextBox();
            this.Command = new System.Windows.Forms.Label();
            this.AnnouncementTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(252)))), ((int)(((byte)(189)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.txtMessage.Location = new System.Drawing.Point(194, 479);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(388, 21);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(5)))), ((int)(((byte)(25)))));
            this.button1.Location = new System.Drawing.Point(588, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 39);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tlpChatLog
            // 
            this.tlpChatLog.AutoScroll = true;
            this.tlpChatLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(43)))));
            this.tlpChatLog.ColumnCount = 1;
            this.tlpChatLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChatLog.Location = new System.Drawing.Point(194, 14);
            this.tlpChatLog.Name = "tlpChatLog";
            this.tlpChatLog.RowCount = 1;
            this.tlpChatLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChatLog.Size = new System.Drawing.Size(439, 450);
            this.tlpChatLog.TabIndex = 6;
            // 
            // MessageTimer
            // 
            this.MessageTimer.Enabled = true;
            this.MessageTimer.Interval = 3000;
            this.MessageTimer.Tick += new System.EventHandler(this.MessageTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(22)))), ((int)(((byte)(100)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group Announcements";
            // 
            // txtAnnouncements
            // 
            this.txtAnnouncements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(178)))));
            this.txtAnnouncements.Location = new System.Drawing.Point(12, 30);
            this.txtAnnouncements.Multiline = true;
            this.txtAnnouncements.Name = "txtAnnouncements";
            this.txtAnnouncements.ReadOnly = true;
            this.txtAnnouncements.Size = new System.Drawing.Size(173, 223);
            this.txtAnnouncements.TabIndex = 8;
            // 
            // Command
            // 
            this.Command.AutoSize = true;
            this.Command.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Command.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command.ForeColor = System.Drawing.Color.White;
            this.Command.Location = new System.Drawing.Point(12, 256);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(168, 208);
            this.Command.TabIndex = 10;
            this.Command.Text = "All Users\r\n/setname [new name]\r\n\r\nModerator\r\n/announce [message]\r\n/ban [username]" +
    "\r\n/delete [messageID]\r\n\r\nOwner\r\n/lock [true or false]\r\n/promote [username]\r\n/dem" +
    "ote [username]\r\n/setpassword [password]";
            // 
            // AnnouncementTimer
            // 
            this.AnnouncementTimer.Enabled = true;
            this.AnnouncementTimer.Interval = 10000;
            this.AnnouncementTimer.Tick += new System.EventHandler(this.AnnouncementTimer_Tick);
            // 
            // ClientChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(22)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(645, 510);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.txtAnnouncements);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlpChatLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientChatForm";
            this.Text = "Chat Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tlpChatLog;
        private System.Windows.Forms.Timer MessageTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnnouncements;
        private System.Windows.Forms.Label Command;
      private System.Windows.Forms.Timer AnnouncementTimer;
   }
}