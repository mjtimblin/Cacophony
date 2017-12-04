﻿using System;
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
            user.UserID = Login(txtIP.Text, int.Parse(txtPort.Text), txtPassword.Text, user);
            if (user.UserID != -1)
            {
                var ClientChat = new ClientChatForm(user, txtIP.Text, int.Parse(txtPort.Text));
                Thread thread = new Thread(ApplicationRunProc);
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(ClientChat);
            }
            else
                MessageBox.Show("Something went wrong!");
        }

        private int Login(string ip, int port, string password, User user)
        {
            var clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect(ip, port);
            AppCode.Message request = new CommandMessage(user.UserID, AppCode.CommandType.ValidateAttempt, password + "|" + user.Alias + "|" + user.PIN);//Might need to change format

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
                    //Validate confirmed should also send back the users userID
                    //user.UserID = response.userID;
                    return user.UserID;
                }
            }
            catch (Exception ex)
            {
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
