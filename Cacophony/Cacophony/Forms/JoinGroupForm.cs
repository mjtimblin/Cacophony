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
using System.Net.Sockets;

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
            User user = new User(-1, txtUsername.Text, txtPIN.Text);
            user.UserID = Login(txtIP.Text, txtPassword.Text, user);
            if (user.UserID != -1)
            {
                var ClientChat = new ClientChatForm(user, txtIP.Text);
                Thread thread = new Thread(ApplicationRunProc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(ClientChat);
            }
        }

        private int Login(string ip, string password, User user)
        {
            var clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect(ip, Server.PORT);
            AppCode.Message request = new CommandMessage(user.UserID, user.Alias, AppCode.CommandType.ValidateAttempt, password + "|" + user.Alias + "|" + user.PIN);//Might need to change format

            //Send password attempt
            NetworkStream networkStream = clientSocket.GetStream();
            byte[] outStream = request.SerializeMessage();
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();

            //Listen for password accepted
            networkStream.ReadTimeout = 5000;
            byte[] bytesFrom = new byte[10025];
            try
            {
                networkStream.Read(bytesFrom, 0, 10025);
                networkStream.ReadTimeout = Timeout.Infinite;
                var response = AppCode.Message.DeserializeMessage(bytesFrom);
                if (response is CommandMessage && ((CommandMessage)response).type == AppCode.CommandType.ValidateConfirm)
                {
                    var serverResponse = ((CommandMessage)response).content.ToString().Split('|');
                    if (serverResponse[0] == "false")
                        MessageBox.Show("Wrong password or PIN.");
                    else
                        return int.Parse(serverResponse[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server did not respond!");
                return -1;
            }
            finally
            {
                networkStream.ReadTimeout = Timeout.Infinite;
            }
            return -1;
        }

        private static void ApplicationRunProc(object state)
        {
            Application.Run(state as Form);
        }
    }
}
