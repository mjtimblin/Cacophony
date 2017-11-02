using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace PrototypeB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //https://www.youtube.com/watch?v=KxdOOk6d_I0
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    command.Parameters.AddWithValue("@PostDate", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@Message", txtInput.Text);

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

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    txtChat.Clear();
                    while (reader.Read())
                    {
                        txtChat.AppendText("[" + reader[3].ToString() + " : " + reader[1].ToString() + "]" + reader[0].ToString() + Environment.NewLine);
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
