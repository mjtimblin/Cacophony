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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tlpChatLog = new System.Windows.Forms.TableLayoutPanel();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(194, 479);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(388, 20);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(588, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tlpChatLog
            // 
            this.tlpChatLog.AutoScroll = true;
            this.tlpChatLog.BackColor = System.Drawing.Color.Gray;
            this.tlpChatLog.ColumnCount = 1;
            this.tlpChatLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChatLog.Location = new System.Drawing.Point(194, 14);
            this.tlpChatLog.Name = "tlpChatLog";
            this.tlpChatLog.RowCount = 1;
            this.tlpChatLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChatLog.Size = new System.Drawing.Size(439, 455);
            this.tlpChatLog.TabIndex = 6;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 3000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group Announcements";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 439);
            this.textBox1.TabIndex = 8;
            // 
            // ClientChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 510);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlpChatLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}