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
        static private List<string> messages = new List<string>();

        static public string[] getMessages()
        {
            updateMessages();
            return messages.ToArray();
        }

        static private void updateMessages()
        {
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
                        messages.Add("[" + reader[3].ToString() + " : " + reader[1].ToString() + "] " + reader[0].ToString() + Environment.NewLine);
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
