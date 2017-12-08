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
        private List<Group> existingGroups;

        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            //Error Checking
            if (string.IsNullOrWhiteSpace(txtGroup.Text))
            {
                MessageBox.Show("Group name cannot be empty!");
                return;
            }
            var group = new Group(txtGroup.Text, txtPassword.Text, Server.PORT);
            var groupID = DatabaseHelper.InsertGroup(group);
            group.GroupID = groupID;
            var userID = DatabaseHelper.InsertUser("owner", groupID, txtPIN.Text);
            group.Owner = userID;
            DatabaseHelper.UpdateGroup(group);

            this.Hide();
            var serverLog = new ServerForm(group);
            Thread thread = new Thread(ApplicationRunProc);
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start(serverLog);
        }

        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }

    }
}
