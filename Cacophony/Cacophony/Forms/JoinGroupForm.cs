using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cacophony.AppCode;

namespace Cacophony.Forms
{
    public partial class JoinGroupForm : Form
    {
        public JoinGroupForm()
        {
            InitializeComponent();
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            this.Hide();//Might need to dispose of this better.
            var userID = -1;
            if (!int.TryParse(txtReturningCode.Text, out userID))
                userID = -1;
            Client client = new Client();
            if(client.StartClient(txtIP.Text, int.Parse(txtPort.Text), txtPassword.Text, userID, txtUsername.Text))
            {
                this.Hide();
                var ClientChat = new ClientChatForm(client);
                Thread thread = new Thread(ApplicationRunProc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(ClientChat);
            }
        }

        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }
    }
}
