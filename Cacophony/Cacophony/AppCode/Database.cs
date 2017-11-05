using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public static class Database
    {
        static private List<Message> messages = new List<Message>();

        static public void AddTextMessage(TextMessage message, string groupName)
        {
            //messages.Add(m);
            //Get groupID from name -> int groupID
            int groupID = -1;
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
                    command.Parameters.AddWithValue("@GroupID", groupID);
                    command.Parameters.AddWithValue("@UserID", message.UserID);
                    command.Parameters.AddWithValue("@PostDate", message.Timestamp);
                    command.Parameters.AddWithValue("@Message", message.Content);

                    command.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    connect.Close();
                }
            }
        }

    }
}
