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

        private List<ClientConnection> clients = new List<ClientConnection>();

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
                clients.Add(cc);
            }
        }

        //Validates the client and listens for incoming messages form the client.
        private void ListenToClient(ClientConnection cc)
        {
            NetworkStream networkStream = cc.TcpC.GetStream();
            while (cc.active)
            {
                try
                {
                    if (cc.TcpC.Connected)
                    {
                        byte[] bytesFrom = new byte[3500000];
                        networkStream.Read(bytesFrom, 0, 3500000);
                        var mes = Message.DeserializeMessage(bytesFrom);//bytes.ToArray());
                        HandleClientMessage(mes, cc);
                    }
                    else
                        cc.active = false;

                }
                catch(Exception ex)
                {
                    parentForm.Log(ex.ToString());
                    //Code to check if user is active.
                }
            }
            clients.Remove(cc);
        }

        //Determines what the server should do given a message.
        private void HandleClientMessage(Message mes, ClientConnection cc)
        {
            DatabaseHelper.mut.WaitOne();
            if (mes is TextMessage)
            {
                TextMessage textMessage = (TextMessage)mes;
                DatabaseHelper.InsertTextMessage(textMessage, group.GroupID);
                parentForm.Log("Text Message from " + textMessage.UserID + ": " + textMessage.Content);
            }
            else if (mes is ImageMessage)
            {
                ImageMessage img = (ImageMessage)mes;
                DatabaseHelper.InsertImageMessage(img, group.GroupID);
                parentForm.Log("Image Message from " + img.UserID);
            }
            else if (mes is CommandMessage)
            {
                CommandMessage command = (CommandMessage)mes;
                if (command.type == CommandType.ValidateAttempt)
                    CmdValidateAttempt(command, cc);
                else if (command.type == CommandType.Ping)
                    parentForm.Log(command.content.ToString());
                else if (command.type == CommandType.RequestMessages)
                    CmdReturnMessages(command, cc);
            }
            DatabaseHelper.mut.ReleaseMutex();
        }

        private void CmdReturnMessages(CommandMessage cmd, ClientConnection cc)
        {
            var textMessages = DatabaseHelper.SelectAllTextMessages(group.GroupID, (DateTime)cmd.content);
            var imageMessages = DatabaseHelper.SelectAllImageMessages(group.GroupID, (DateTime)cmd.content);
            List<Message> allMessages = new List<Message>();
            allMessages.AddRange(textMessages);
            allMessages.AddRange(imageMessages);
            CommandMessage response = new CommandMessage(-1, "server", CommandType.RequestMessages, allMessages.OrderBy(m => m.PostDate).ToArray());
            SendToClient(response, cc);
        }

        private void CmdValidateAttempt(CommandMessage cmd, ClientConnection cc)
        {
            var content = cmd.content.ToString().Split('|');
            if (content[0] == group.Password)
            {
                var user = DatabaseHelper.SelectUser(content[1], group.GroupID);
                int userID;
                if (user == null)
                {
                    userID = DatabaseHelper.InsertUser(content[1], group.GroupID, content[2]);
                    CommandMessage success = new CommandMessage(-1, "server", CommandType.ValidateConfirm, "true|" + userID);
                    SendToClient(success, cc);
                }
                else if (user.PIN != content[2])
                {
                    CommandMessage fail = new CommandMessage(-1, "server", CommandType.ValidateConfirm, "false|-1");
                    SendToClient(fail, cc);
                }
                else
                {
                    userID = user.UserID;
                    CommandMessage success = new CommandMessage(-1, "server", CommandType.ValidateConfirm, "true|" + userID);
                    SendToClient(success, cc);
                }
            }
            else
            {
                CommandMessage fail = new CommandMessage(-1, "server", CommandType.ValidateConfirm, "false|-1");
                SendToClient(fail, cc);
            }
            cc.active = false;
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

    class ClientConnection
    {
        public bool active = true;
        public Thread ListeningThread;
        public TcpClient TcpC;
    }
}
