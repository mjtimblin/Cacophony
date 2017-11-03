using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PrototypeE
{
   public partial class ChatRoom_Client_ : Form
   {
      System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
      public string IP;
      public int port = 5764;
      public string passwordProvided;

      public ChatRoom_Client_()
      {
         InitializeComponent();
      }

      private void ChatRoom_Client__Load(object sender, EventArgs e)
      {

      }

      public void StartClient()
      {
         clientSocket.Connect(IP, port);
         Thread newThread = new Thread(ListenToServer);
         newThread.Start();
         Message mes = new Message("ValidateAttempt", "NameTest", passwordProvided, DateTime.Now.ToString());
         SendToServer(mes);
         //Password operations
      }

      private void ListenToServer()
      {
         while (true)
         {
            NetworkStream networkStream = clientSocket.GetStream();
            byte[] bytesFrom = new byte[10025];
            networkStream.Read(bytesFrom, 0, 10025);
            var mes = new Message(bytesFrom);

            HandleServerMessage(mes);
         }
      }

      private void HandleServerMessage(Message message)
      {
         if (message.command == "ValidateFail")
            Prompt("Incorrect Password");
         else if (message.command == "ValidatePass")
            Prompt("Correct Password");
         else
            Log(message.message);
      }

      private void SendToServer(Message message)
      {
         NetworkStream networkStream = clientSocket.GetStream();
         byte[] outStream = message.ToJsonBytes();
         networkStream.Write(outStream, 0, outStream.Length);
         networkStream.Flush();
         txtMessage.Text = "";
      }

      public void Log(String text)
      {
         if (this.InvokeRequired)
         {
            this.Invoke(new Action<string>(Log), new object[] { text });
            return;
         }
         txtChat.AppendText(Environment.NewLine + text);
      }

      private void Prompt(string message)
      {
         if (InvokeRequired)
         {
            this.Invoke(new Action(() => Prompt(message)));
            return;
         }
         MessageBox.Show(message);
      }

      private void btnSend_Click(object sender, EventArgs e)
      {
         SendToServer(new Message("Message", "NameTest", txtMessage.Text, DateTime.Now.ToString()));
      }
   }
}
