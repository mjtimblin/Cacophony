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
    public partial class ClientChatForm : Form
    {
        private Client client;
        public ClientChatForm(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void ClientChatForm_Load(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
