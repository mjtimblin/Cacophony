using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cacophony.AppCode;
using Cacophony.Forms;
using System.IO;
using Cacophony.AppCode;

namespace Cacophony.Forms
{
    public partial class ClientChatForm : Form
    {
        public Client client;

        public ClientChatForm(User user, string IP)
        {
            this.client = new Client();
            client.parentForm = this;
            client.StartClient(IP, Server.PORT, user);
            InitializeComponent();
        }

        private void ClientChatForm_Load(object sender, EventArgs e)
        {
            this.Show();
            client.RequestMessages();
        }

        private void btnGetMessages_Click(object sender, EventArgs e)
        {
            client.RequestMessages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.JPEG)|*.BMP;*.JPG;*.PNG;*.JPEG";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var imageArray = File.ReadAllBytes(openFileDialog1.FileName);
                client.SendImage(imageArray, Path.GetExtension(openFileDialog1.FileName));
            }
        }

        public void ClearChatLog()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ClearChatLog));
                return;
            }
            tlpChatLog.Controls.Clear();
        }
		
		public void PromptUser(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(PromptUser), new object[] { message });
                return;
            }
            MessageBox.Show(message);
        }

        public void ShowMessage(AppCode.Message message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<AppCode.Message>(ShowMessage), new object[] { message });
                return;
            }

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tlpChatLog.Padding = new Padding(5);

            var panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.AutoSize = true;
            panel.BackColor = Color.DimGray;
            panel.Padding = new Padding(10);
            if (message is TextMessage)
            {
                TextMessage text = (TextMessage)message;
                var lbl = new Label();
                lbl.ForeColor = Color.White;
                lbl.Dock = DockStyle.Top;
                lbl.MaximumSize = new Size(tlpChatLog.Width - 60, 0);
                lbl.Text = "(#" + text.MessageID + ") " + text.UserAlias + ":" + Environment.NewLine + text.Content;
                lbl.AutoSize = true;
                panel.Controls.Add(lbl);
                tlpChatLog.Controls.Add(panel);
            }
            else if(message is ImageMessage)
            {
                ImageMessage image = (ImageMessage)message;
                var picBox = new PictureBox();
                using (var ms = new MemoryStream(image.ImageData))
                {
                    var lbl = new Label();
                    lbl.ForeColor = Color.White;
                    lbl.Dock = DockStyle.Top;
                    lbl.Text = image.UserAlias + ":";
                    lbl.AutoSize = true;
                    Image originalImage = Image.FromStream(ms);
                    float scale = (float)(tlpChatLog.Width - 40) / (float)originalImage.Width;
                    Bitmap resizedImage = new Bitmap(originalImage, (int)(originalImage.Width * scale), (int)(originalImage.Height * scale));
                    picBox.Dock = DockStyle.Top;
                    picBox.Image = resizedImage;
                    picBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    panel.Controls.Add(picBox);
                    panel.Controls.Add(lbl);
                    tlpChatLog.Controls.Add(panel);
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            client.RequestMessages();
        }

        private void ClientChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //client.CloseConnection();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                if (txtMessage.Text.StartsWith("/"))
                    client.SendCommandMessage(txtMessage.Text);
                else
                    client.SendTextMessage(txtMessage.Text);
                client.RequestMessages();
                txtMessage.Text = "";
            }
        }
    }
}
