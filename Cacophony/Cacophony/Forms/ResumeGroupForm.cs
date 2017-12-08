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
    public partial class ResumeGroupForm : Form
    {
        List<Group> existingGroups = new List<Group>();

        public ResumeGroupForm()
        {
            InitializeComponent();
        }

        private void ResumeGroupForm_Load(object sender, EventArgs e)
        {
            existingGroups = DatabaseHelper.SelectAllGroups();
            foreach (var group in existingGroups)
            {
                ddlGroups.Items.Add(group.GroupID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ddlGroups.Text != null)
            {
                var selectedGroup = existingGroups.Where(g => g.GroupID.ToString() == ddlGroups.Text).ToArray();
                if (selectedGroup.Length == 0)
                    return;
                this.Hide();
                selectedGroup[0].Port = Server.PORT;
                var serverLog = new ServerForm(selectedGroup[0]);
                Thread thread = new Thread(ApplicationRunProc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(serverLog);
            }
        }

        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }
    }
}
