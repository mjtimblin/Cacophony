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

namespace Cacophony.Forms
{
    public partial class ServerForm : Form
    {
        private Server server;
        public ServerForm(Group group)
        {
            server = new Server();
            server.group = group;
            server.parentForm = this;
            InitializeComponent();
        }

        public void StartServer(Group group)
        {
            if (server != null)
                return;
        }

        private void ServerChatForm_Load(object sender, EventArgs e)
        {
            bool success = server.StartServer();
            this.Show();
        }

        public void Log(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { text });
                return;
            }
            txtConsole.AppendText(Environment.NewLine + text);
            txtConsole.ScrollToCaret();
        }

        public void UpdateOwnerDisplay(string ownerName, int ownerPIN)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { ownerName, ownerPIN });
                return;
            }
            txtOwnerName.Text = ownerName;
            txtOwnerPIN.Text = ownerPIN.ToString();
        }
    }
}
