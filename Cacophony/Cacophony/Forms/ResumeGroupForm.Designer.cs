namespace Cacophony.Forms
{
    partial class ResumeGroupForm
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
            this.ddlGroups = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlGroups
            // 
            this.ddlGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGroups.FormattingEnabled = true;
            this.ddlGroups.Location = new System.Drawing.Point(12, 12);
            this.ddlGroups.Name = "ddlGroups";
            this.ddlGroups.Size = new System.Drawing.Size(212, 21);
            this.ddlGroups.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Resume Group";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResumeGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 74);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ddlGroups);
            this.Name = "ResumeGroupForm";
            this.Text = "ResumeGroupForm";
            this.Load += new System.EventHandler(this.ResumeGroupForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlGroups;
        private System.Windows.Forms.Button button1;
    }
}