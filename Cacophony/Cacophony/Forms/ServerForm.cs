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
        public ServerForm(Server server)
        {
            this.server = server;
            InitializeComponent();
        }

        private void ServerChatForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loaded");
            this.Show();
        }
    }
}
