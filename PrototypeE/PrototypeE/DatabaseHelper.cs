using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeE
{
   static class DatabaseHelper
   {
      static private List<Message> messages = new List<Message>();

      static public Message[] getMessages()
      {
         updateMessages();
         return messages.ToArray();
      }

      static public void addMessage(Message m)
      {
         messages.Add(m);
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "INSERT INTO Messages (GroupID, UserID, PostDate, Message) values (@GroupID, @UserID, @PostDate, @Message)";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Messages", connect);
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupID", 1);
               command.Parameters.AddWithValue("@UserID", 1);
               command.Parameters.AddWithValue("@PostDate", m.timestamp);
               command.Parameters.AddWithValue("@Message", m.message);

               command.ExecuteNonQuery();
               connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
      }

      static private void updateMessages()
      {
         messages.Clear();
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "Select Messages.Message, Messages.PostDate, Messages.UserID, Users.Alias From Messages Inner Join Users On Messages.UserID = Users.UserID Where GroupID = 1";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  messages.Add(new Message(reader[2].ToString(), reader[3].ToString(), reader[0].ToString(), reader[1].ToString()));
               }
               connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
      }
   }
}
