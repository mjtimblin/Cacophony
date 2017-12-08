using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Cacophony.AppCode;
using Cacophony.Forms;

namespace Cacophony.AppCode
{
    public class Server
    {
        public Group group;
        //private DatabaseHelper db; Probably Static
        public ServerForm parentForm;

        private TcpListener clientListener;

        public static int PORT = 5764;

        public bool StartServer()
        {
            Thread AcceptClientThread = new Thread(AcceptClient);
            AcceptClientThread.Start();
            parentForm.Log("--Server initialized.");
            return true;
        }

        private void AcceptClient()
        {
            clientListener = new TcpListener(GetLocalIP(), group.Port);
            clientListener.Start();
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = clientListener.AcceptTcpClient();
                ClientConnection cc = new ClientConnection();
                cc.TcpC = clientSocket;
                cc.ListeningThread = new Thread(() => ListenToClient(cc));
                cc.ListeningThread.Start();
            }
        }

        //Validates the client and listens for incoming messages form the client.
        private void ListenToClient(ClientConnection cc)
        {
            try
            {
                NetworkStream networkStream = cc.TcpC.GetStream();
                while (true)
                {
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, 10025);
                    var mes = Message.DeserializeMessage(bytesFrom);
                    HandleClientMessage(mes, cc);
                }
            }
            catch (Exception ex)
            {
                parentForm.Log(ex.ToString());
                return;
            }
        }

        //Determines what the server should do given a message.
        private void HandleClientMessage(Message mes, ClientConnection cc)
        {
            if (mes is TextMessage)
            {
                Console.WriteLine("text");
            }
            else if (mes is ImageMessage)
            {
                Console.WriteLine("image");
            }
            else if (mes is CommandMessage)
            {
                CommandMessage command = (CommandMessage)mes;
                if (command.type == CommandType.ValidateAttempt)
                    CmdValidateAttempt(command, cc);
                else if (command.type == CommandType.Ping)
                    parentForm.Log(command.content);
            }
        }

        private void CmdValidateAttempt(CommandMessage cmd, ClientConnection cc)
        {
            var content = cmd.content.Split('|');
            if (content[0] == group.Password)
            {
                var user = DatabaseHelper.SelectUser(content[1], group.GroupID);
                int userID;
                if (user == null)
                {
                    userID = DatabaseHelper.InsertUser(content[1], group.GroupID, content[2]);
                    CommandMessage success = new CommandMessage(0, CommandType.ValidateConfirm, "true|" + userID);
                    SendToClient(success, cc);
                }
                else if (user.PIN != content[2])
                {
                    CommandMessage fail = new CommandMessage(0, CommandType.ValidateConfirm, "false|-1");
                    SendToClient(fail, cc);
                }
                else
                {
                    userID = user.UserID;
                    CommandMessage success = new CommandMessage(0, CommandType.ValidateConfirm, "true|" + userID);
                    SendToClient(success, cc);
                }
            }
            else
            {
                CommandMessage fail = new CommandMessage(0, CommandType.ValidateConfirm, "false|-1");
                SendToClient(fail, cc);
            }
        }

        //Sends a message to a client.
        private void SendToClient(Message message, ClientConnection cc)
        {
            NetworkStream networkStream = cc.TcpC.GetStream();
            byte[] outStream = message.SerializeMessage();
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
        }

        //Gets the local IP address of this computer.
        private static IPAddress GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipaddr in host.AddressList)
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipaddr;
                }
            }
            throw new Exception("No local IP address...wait? what?");
        }
    }

    struct ClientConnection
    {
        public User Client;
        public Thread ListeningThread;
        public TcpClient TcpC;
    }
}
