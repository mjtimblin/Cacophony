using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Cacophony.AppCode
{
    public class Client
    {
        private TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        private Thread serverListener;
        private User user;
        //public string IP;
        //public int port = 5764;

        public bool StartClient(string ip, int port, string password, int userID, string username)
        {
            user = new User();
            user.Username = username;
            user.UserID = userID;

            clientSocket.Connect(ip, port);
            var isValidated = Login(password);
            if(isValidated)
            {
                serverListener = new Thread(ListenToServer);
                serverListener.Start();
            }
            return isValidated;
        }

        private bool Login(string password)
        {
            Message request = new CommandMessage(user.UserID, CommandType.ValidateAttempt, password + "|" + user.Username);//Might need to change format
            SendToServer(request);
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.ReadTimeout = 5000;
            byte[] bytesFrom = new byte[10025];
            try
            {
                networkStream.Read(bytesFrom, 0, 10025);
                networkStream.ReadTimeout = Timeout.Infinite;
                var response = Message.DeserializeMessage(bytesFrom);
                if (response is CommandMessage && ((CommandMessage)response).type == CommandType.ValidateConfirm)
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                networkStream.ReadTimeout = Timeout.Infinite;
            }
            return false;
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
