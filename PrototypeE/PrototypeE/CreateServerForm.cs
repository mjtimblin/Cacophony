using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeE
{
    public partial class CreateServerForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public CreateServerForm()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();//Might need to dispose of this better.
            Thread serverThread = new Thread(() => CreateForm(txtPassword.Text));
            serverThread.Start();
        }

        private void CreateForm(string password)
        {
            var HostChat = new ChatRoom_Host_();
            HostChat.Password = txtPassword.Text;
            HostChat.StartHost();
            HostChat.ShowDialog();
        }
    }
}
