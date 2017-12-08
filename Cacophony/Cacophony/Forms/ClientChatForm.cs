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
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            client.SendTextMessage(txtMessage.Text);
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
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var imageArray = File.ReadAllBytes(openFileDialog1.FileName);
                client.SendImage(imageArray, Path.GetExtension(openFileDialog1.FileName));
            }
        }
    }
}
