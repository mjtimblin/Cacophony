using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cacophony.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            var createForm = new CreateGroupForm();
            createForm.Show();
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            var joinForm = new JoinGroupForm();
            joinForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resumeForm = new ResumeGroupForm();
            resumeForm.Show();
        }
    }
}
