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
      private DateTime lastUpdate = new DateTime();

      private List<string> recievedMessages = new List<string>();

      public ClientChatForm parentForm;

      public bool StartClient(string ip, int port, User user)
      {
         this.user = user;
         clientSocket.Connect(ip, port);
         serverListener = new Thread(ListenToServer);
         serverListener.Start();
         CommandMessage cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Ping, user.Alias + " has joined.");
         SendToServer(cmd);
         return true;
      }

      private void ListenToServer()
      {
         while (true)
         {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[3500000];
                networkStream.Read(bytesFrom, 0, 3500000);
                var mes = Message.DeserializeMessage(bytesFrom);

                HandleServerMessage(mes);
            }
            catch(Exception ex)
            {
                parentForm.Close();
                return;
            }
         }
      }

      private void SendToServer(Message message)
      {
         NetworkStream networkStream = clientSocket.GetStream();
         byte[] outStream = message.SerializeMessage();
         networkStream.Write(outStream, 0, outStream.Length);
         networkStream.Flush();
      }

      private void HandleServerMessage(Message message)
      {
         if (message is CommandMessage)
         {
            CommandMessage cmd = (CommandMessage)message;
            if (cmd.type == CommandType.NewMessages)
            {
               var messages = (Message[])cmd.content;
               foreach (var mes in messages)
               {
                  string mesID = ((mes is TextMessage) ? "txt" : "img") + mes.MessageID;
                  if (!recievedMessages.Contains(mesID))
                  {
                     recievedMessages.Add(mesID);
                     parentForm.ShowMessage(mes);
                  }
               }
            }
            if (cmd.type == CommandType.GetGroupAnnouncements)
            {
               parentForm.SetAnnouncement(cmd.content.ToString());
            }
         }
      }

      public void SendTextMessage(string text)
      {
         TextMessage message = new TextMessage(user.UserID, user.Alias, text);
         SendToServer(message);

      }

      public void RequestMessages()
      {
         CommandMessage cmd = new CommandMessage(user.UserID, user.Alias, CommandType.RequestMessages, lastUpdate);
         lastUpdate = DateTime.UtcNow;
         lastUpdate = new DateTime(lastUpdate.Year, lastUpdate.Month, lastUpdate.Day, lastUpdate.Hour, lastUpdate.Minute, lastUpdate.Second, lastUpdate.Kind);
         SendToServer(cmd);
      }

      public void SendImage(byte[] imageData, string fileExtension)
      {
         ImageMessage img = new ImageMessage(user.UserID, user.Alias, imageData, fileExtension);
         SendToServer(img);
      }

      public void SendCommandMessage(string command)
      {
         try
         {
            var values = command.Remove(0, 1).Split(' ');
            var parameters = command.Split(' ').ToList<string>();
            parameters.RemoveAt(0);
            var param = string.Join(" ", parameters.ToArray());
                CommandMessage cmd = null;
            if (values[0] == "promote")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Promote, param);
            else if (values[0] == "demote")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Demote, param);
            else if (values[0] == "lock")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Lock, bool.Parse(parameters[0]));
            else if (values[0] == "setpassword")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.SetPassword, param);
            else if (values[0] == "setname")
            {
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.SetDisplayName, param);
               user.Alias = param;
            }
            else if (values[0] == "delete")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.DeleteMessage, int.Parse(parameters[0]));
            else if (values[0] == "ban")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Ban, param);
            else if (values[0] == "pin")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.Pin, parameters[0] + "|" + parameters[1]);
            else if (values[0] == "announce")
               cmd = new CommandMessage(user.UserID, user.Alias, CommandType.SetGroupAnnouncements, param);
            if (cmd != null)
               SendToServer((Message)cmd);
         }
         catch (Exception ex)
         {
            parentForm.PromptUser("Improper command format!");
         }
      }

      public void RequestAnnouncements()
      {
         CommandMessage cmd = new CommandMessage(user.UserID, user.Alias, CommandType.GetGroupAnnouncements, "");
         SendToServer(cmd);
      }
   }
}
