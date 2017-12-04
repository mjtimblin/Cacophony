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
            //Error Checking
            if (string.IsNullOrWhiteSpace(cbxGroupName.Text))
            {
                MessageBox.Show("Group name cannot be empty!");
                return;
            }
            int portNum;
            if(string.IsNullOrWhiteSpace(txtPort.Text) || !int.TryParse(txtPort.Text, out portNum) || portNum < 0 || portNum > 9999)
            {
                MessageBox.Show("Invalid Port!");
                return;
            }

            //Check if group exists in database, or create a new group.
            Group group = null;
            //group = SelectGroupByID(cbxGroupName.SelectedItem);  Should return a group object or null if doesnt exist
            if(group == null)
            {
                group = new Group(cbxGroupName.Text, txtPassword.Text, portNum);
            }

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

        private void CreateGroupForm_Load(object sender, EventArgs e)
        {
            //Populate ComboBox with all groups in the database.
            //string[] groups= null;
            //groups = SelectAllGroups();
            //cbxGroupName.Items.AddRange(groups);
        }
    }
}
