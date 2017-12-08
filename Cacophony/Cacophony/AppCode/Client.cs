using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Cacophony.Forms;

namespace Cacophony.AppCode
{
    public class Client
    {
        private TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private Thread serverListener;
        private User user;

        public ClientChatForm parentForm;

        public bool StartClient(string ip, int port, User user)
        {
            this.user = user;
            clientSocket.Connect(ip, port);
            serverListener = new Thread(ListenToServer);
            serverListener.Start();
            CommandMessage cmd = new CommandMessage(user.UserID, CommandType.Ping, user.Alias + " has joined.");
            SendToServer(cmd);
            return true;
        }

        private void ListenToServer()
        {
            while (true)
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[10025];
                networkStream.Read(bytesFrom, 0, 10025);
                var mes = Message.DeserializeMessage(bytesFrom);

                //HandleServerMessage(mes);
            }
        }

        private void SendToServer(Message message)
        {
            NetworkStream networkStream = clientSocket.GetStream();
            byte[] outStream = message.SerializeMessage();
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
            //txtMessage.Text = "";
        }
    }
}
