using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PrototypeD
{
    public partial class ChatRoom_Host_ : Form
    {
        private TcpListener serverSocket;
        private List<Thread> clientThreads = new List<Thread>();
        private List<ClientConnection> clients = new List<ClientConnection>();

        private string serverPassword = "password";

        public string Password
        {
            get { return serverPassword; }
            set { serverPassword = value; }
        }

        public ChatRoom_Host_()
        {
            InitializeComponent();
        }

        private void ChatRoom_Host__Load(object sender, EventArgs e)
        {
            //On form load event.  Might want to check rights here.
        }

        public void StartHost()
        {
            //Might want to add functionality to change port.
            Thread AcceptClientThread = new Thread(AcceptClient);
            AcceptClientThread.Start();
        }

        private void AcceptClient()
        {
            serverSocket = new TcpListener(GetLocalIP(), 5764);
            serverSocket.Start();
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = serverSocket.AcceptTcpClient();
                ClientConnection cc = new ClientConnection();
                cc.Client = new Client(clientSocket.Client.RemoteEndPoint.ToString());
                cc.TcpC = clientSocket;
                cc.ListeningThread = new Thread(() => ListenToClient(cc));
                Log(">> Client Connected");
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
                    var mes = new Message(bytesFrom);
                    HandleClientMessage(mes, cc);
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                return;
            }
        }

        //Determines what the server should do given a message.
        private void HandleClientMessage(Message mes, ClientConnection cc)
        {
            if (!cc.Client.isValidated && mes.command != "ValidateAttempt")
                return;
            Log("Message from: " + mes.name + "  Command: " + mes.command + "  Message: " + mes.message);
            switch (mes.command)
            {
                case "ValidateAttempt":
                    if (mes.message == serverPassword)
                    {
                        Log(mes.name + " authenticated.");
                        cc.Client.isValidated = true;
                    }
                    break;
                case "Message"://Relays message to all clients
                    Log(mes.message);
                    //Call to update users
                    break;
            }
        }

        //Sends a message to a client.
        private void SendToClient(Message message, ClientConnection cc)
        {
            NetworkStream networkStream = cc.TcpC.GetStream();
            byte[] outStream = message.ToJsonBytes();
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

        //Posts text to server debug.
        public void Log(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { text });
                return;
            }
            txtLog.AppendText(Environment.NewLine + text);
        }

        //Posts text on the chat textbox.
        public void ChatPost(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { text });
                return;
            }
            txtChat.AppendText(Environment.NewLine + text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //Unique to host, since he sits on the database.
        }
    }

    struct ClientConnection
    {
        public Client Client;
        public Thread ListeningThread;
        public TcpClient TcpC;
    }
}
