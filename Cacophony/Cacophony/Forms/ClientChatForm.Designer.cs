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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnGetMessages = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tlpChatLog = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(13, 478);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(364, 20);
            this.txtMessage.TabIndex = 2;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(383, 478);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(69, 23);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnGetMessages
            // 
            this.btnGetMessages.Location = new System.Drawing.Point(308, 449);
            this.btnGetMessages.Name = "btnGetMessages";
            this.btnGetMessages.Size = new System.Drawing.Size(69, 23);
            this.btnGetMessages.TabIndex = 4;
            this.btnGetMessages.Text = "Get";
            this.btnGetMessages.UseVisualStyleBackColor = true;
            this.btnGetMessages.Click += new System.EventHandler(this.btnGetMessages_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tlpChatLog
            // 
            this.tlpChatLog.AutoScroll = true;
            this.tlpChatLog.ColumnCount = 1;
            this.tlpChatLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChatLog.Location = new System.Drawing.Point(13, 13);
            this.tlpChatLog.Name = "tlpChatLog";
            this.tlpChatLog.RowCount = 1;
            this.tlpChatLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChatLog.Size = new System.Drawing.Size(439, 413);
            this.tlpChatLog.TabIndex = 6;
            // 
            // ClientChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 510);
            this.Controls.Add(this.tlpChatLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGetMessages);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientChatForm";
            this.Text = "ClientChatForm";
            this.Load += new System.EventHandler(this.ClientChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnGetMessages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tlpChatLog;
    }
}