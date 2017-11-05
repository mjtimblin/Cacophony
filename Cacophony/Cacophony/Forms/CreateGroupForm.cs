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
using System.Threading;

namespace Cacophony.Forms
{
    public partial class CreateGroupForm : Form
    {
        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group(cbxGroupName.Text, txtPassword.Text, int.Parse(txtPort.Text), 0);
            Server server = new Server();
            if(server.StartServer(group))
            {
                this.Hide();
                var HostChat = new ServerChatForm(server);
                Thread thread = new Thread(ApplicationRunProc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(HostChat);
            }
        }

        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }
    }
}
