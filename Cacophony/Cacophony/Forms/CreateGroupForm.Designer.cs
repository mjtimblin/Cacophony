namespace Cacophony.Forms
{
    partial class CreateGroupForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateGroupForm));
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.txtPassword = new System.Windows.Forms.TextBox();
         this.btnCreateGroup = new System.Windows.Forms.Button();
         this.txtGroup = new System.Windows.Forms.TextBox();
         this.txtPIN = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.ForeColor = System.Drawing.Color.White;
         this.label2.Location = new System.Drawing.Point(1, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(61, 15);
         this.label2.TabIndex = 1;
         this.label2.Text = "Password:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.ForeColor = System.Drawing.Color.White;
         this.label3.Location = new System.Drawing.Point(1, 40);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(76, 15);
         this.label3.TabIndex = 2;
         this.label3.Text = "GroupName:";
         // 
         // txtPassword
         // 
         this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(229)))), ((int)(((byte)(188)))));
         this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtPassword.Location = new System.Drawing.Point(74, 6);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(199, 20);
         this.txtPassword.TabIndex = 0;
         // 
         // btnCreateGroup
         // 
         this.btnCreateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(9)))), ((int)(((byte)(25)))));
         this.btnCreateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnCreateGroup.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCreateGroup.ForeColor = System.Drawing.Color.White;
         this.btnCreateGroup.Location = new System.Drawing.Point(73, 90);
         this.btnCreateGroup.Name = "btnCreateGroup";
         this.btnCreateGroup.Size = new System.Drawing.Size(199, 23);
         this.btnCreateGroup.TabIndex = 3;
         this.btnCreateGroup.Text = "Create Group";
         this.btnCreateGroup.UseVisualStyleBackColor = false;
         this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
         // 
         // txtGroup
         // 
         this.txtGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(229)))), ((int)(((byte)(188)))));
         this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtGroup.Location = new System.Drawing.Point(74, 38);
         this.txtGroup.Name = "txtGroup";
         this.txtGroup.Size = new System.Drawing.Size(199, 20);
         this.txtGroup.TabIndex = 1;
         // 
         // txtPIN
         // 
         this.txtPIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(229)))), ((int)(((byte)(188)))));
         this.txtPIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtPIN.Location = new System.Drawing.Point(74, 64);
         this.txtPIN.MaxLength = 4;
         this.txtPIN.Name = "txtPIN";
         this.txtPIN.Size = new System.Drawing.Size(79, 20);
         this.txtPIN.TabIndex = 2;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.ForeColor = System.Drawing.Color.White;
         this.label4.Location = new System.Drawing.Point(1, 66);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(67, 15);
         this.label4.TabIndex = 10;
         this.label4.Text = "Owner PIN:";
         // 
         // CreateGroupForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.ClientSize = new System.Drawing.Size(284, 127);
         this.Controls.Add(this.txtPIN);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.txtGroup);
         this.Controls.Add(this.btnCreateGroup);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "CreateGroupForm";
         this.Text = "Create Group";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label label4;
    }
}