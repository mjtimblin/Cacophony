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
    }
}
