using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cacophony.AppCode
{
   static class DatabaseHelper
   {
        public static Mutex mut = new Mutex();

        public static int InsertUser(string alias, int groupID, String pin)
      {
         int userId = -1;
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "INSERT INTO Users (Alias, GroupID, PIN) VALUES (@Alias, @GroupID, @PIN)";
         string QueryText2 = "Select @@Identity";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Users", connect);
               command.Connection = connect;
               command.Parameters.AddWithValue("@Alias", alias);
               command.Parameters.AddWithValue("@GroupID", groupID);
               command.Parameters.AddWithValue("@PIN", pin);

                command.ExecuteNonQuery();
                command.CommandText = QueryText2;
                userId = (int) command.ExecuteScalar();
               connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return userId;
      }

      public static int InsertGroup(Group group)
      {
         int groupId = -1;
        String modList = string.Join(",", group.Moderators);

         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "INSERT INTO Groups (GroupName, ModList, OwnerID, [Password]) VALUES (@GroupName, @ModList, @OwnerID, @Password)";
         string QueryText2 = "Select @@Identity";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))//OUTPUT GroupID
            {
            try
            {
               //OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Groups", connect);
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupName", group.GroupName);
               command.Parameters.AddWithValue("@ModList", modList);
               command.Parameters.AddWithValue("@OwnerID", group.Owner);
               command.Parameters.AddWithValue("@Password", group.Password);

               command.ExecuteNonQuery();
               command.CommandText = QueryText2;
               groupId = (int)command.ExecuteScalar();
               connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return groupId;
      }

        public static int UpdateGroup(Group group)
        {
            int groupId = -1;
            String modList = string.Join(",", group.Moderators);

            OleDbConnection connect = new OleDbConnection();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
            string QueryText = "UPDATE Groups SET GroupName = @GroupName, ModList = @ModList, OwnerID = @OwnerID, [Password] = @Password WHERE GroupID = " + group.GroupID;
            connect.Open();
            using (OleDbCommand command = new OleDbCommand(QueryText))
            {
                try
                {
                    command.Connection = connect;
                    command.Parameters.AddWithValue("@GroupName", group.GroupName);
                    command.Parameters.AddWithValue("@ModList", modList);
                    command.Parameters.AddWithValue("@OwnerID", group.Owner);
                    command.Parameters.AddWithValue("@Password", group.Password);

                    command.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connect.Close();
                }
            }
            return groupId;
        }

        public static void InsertTextMessage(TextMessage message, int groupID)
      {
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "INSERT INTO TextMessages (GroupID, UserID, PostDate, Content) VALUES (@GroupID, @UserID, @PostDate, @Content)";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupID", groupID);
               command.Parameters.AddWithValue("@UserID", message.UserID);
               command.Parameters.AddWithValue("@PostDate", message.PostDate.ToString());
               command.Parameters.AddWithValue("@Content", message.Content);

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

      public static void InsertImageMessage(ImageMessage message, int groupID)
      {
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "INSERT INTO ImageMessages (GroupID, UserID, PostDate, ImageData, FileExt) VALUES (@GroupID, @UserID, @PostDate, @ImageData, @FileExt)";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               OleDbDataAdapter da = new OleDbDataAdapter("INSERT INTO Users", connect);
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupID", groupID);
               command.Parameters.AddWithValue("@UserID", message.UserID);
               command.Parameters.AddWithValue("@PostDate", message.PostDate.ToString());
               command.Parameters.AddWithValue("@ImageData", Convert.ToBase64String(message.ImageData));
               command.Parameters.AddWithValue("@FileExt", message.FileExtension);

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

      public static User SelectUserById(int userId)
      {
         User user = null;
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "SELECT Users.UserID, Users.Alias, Users.PIN FROM Users WHERE UserID = @UserID";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               command.Parameters.AddWithValue("@UserID", user.UserID);
               OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  user = new User(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
               }
                    reader.Close();
                    connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return user;
      }

      public static User SelectUser(string alias, int groupId)
      {
         User user = null;
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "SELECT Users.UserID, Users.Alias, Users.PIN FROM Users WHERE Alias = @Alias AND GroupID = @GroupID";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               command.Parameters.AddWithValue("@Alias", alias);
               command.Parameters.AddWithValue("@GroupID", groupId);
               OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  user = new User(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
               }
               reader.Close();
               connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return user;
      }

      public static List<Group> SelectAllGroups()
      {
         List<Group> groups = new List<Group>();
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "SELECT Groups.GroupID, Groups.GroupName, Groups.Password, Groups.Modlist, Groups.OwnerId FROM Groups";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  int groupId = int.Parse(reader[0].ToString());
                  String groupName = reader[1].ToString();
                  String password = reader[2].ToString();
                    List<int> moderatorList = new List<int>();
                    if (!string.IsNullOrWhiteSpace(reader[3].ToString()))
                        moderatorList = reader[3].ToString().Split(',').Select(int.Parse).ToList();
                    int ownerId = -1;
                    if(!string.IsNullOrWhiteSpace(reader[4].ToString()))
                        ownerId = int.Parse(reader[4].ToString());
                  groups.Add(new Group(groupId, groupName, password, moderatorList, ownerId));
               }
                    reader.Close();
                    connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return groups;
      }

      public static List<TextMessage> SelectAllTextMessages(int groupId, DateTime fromDate)
      {
         List<TextMessage> messages = new List<TextMessage>();
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "SELECT TextMessages.TextID, TextMessages.UserID, TextMessages.PostDate, TextMessages.Content, Users.Alias FROM TextMessages INNER JOIN Users ON Users.UserID = TextMessages.UserID WHERE TextMessages.GroupID = @GroupID AND TextMessages.PostDate >= @FromDate";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupID", groupId);
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  int textId = int.Parse(reader[0].ToString());
                  int userId = int.Parse(reader[1].ToString());
                  DateTime postDate = DateTime.Parse(reader[2].ToString());
                  String content = reader[3].ToString();
                        string userAlias = reader[4].ToString();

                  messages.Add(new TextMessage(userId, userAlias, textId, postDate, content));
               }
                    reader.Close();
                    connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return messages;
      }

      public static List<ImageMessage> SelectAllImageMessages(int groupId, DateTime fromDate)
      {
         List<ImageMessage> messages = new List<ImageMessage>();
         OleDbConnection connect = new OleDbConnection();
         connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.Combine(Environment.CurrentDirectory, @"Data\..\..\..\", "DBA.accdb");
         string QueryText = "SELECT ImageMessages.ImageID, ImageMessages.UserID, ImageMessages.PostDate, ImageMessages.ImageData, ImageMessages.FileExt, Users.Alias FROM ImageMessages INNER JOIN Users ON Users.UserID = ImageMessages.UserID WHERE ImageMessages.GroupID = @GroupID AND ImageMessages.PostDate >= @FromDate";
         connect.Open();
         using (OleDbCommand command = new OleDbCommand(QueryText))
         {
            try
            {
               command.Connection = connect;
               command.Parameters.AddWithValue("@GroupID", groupId);
                    command.Parameters.AddWithValue("@FromDate", fromDate);
               OleDbDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  int imageId = int.Parse(reader[0].ToString());
                  int userId = int.Parse(reader[1].ToString());
                  DateTime postDate = DateTime.Parse(reader[2].ToString());
                  byte[] imageData = Convert.FromBase64String(reader[3].ToString());
                  String fileExt = reader[4].ToString();
                        string userAlias = reader[5].ToString();

                  messages.Add(new ImageMessage(userId, userAlias, imageId, postDate, imageData, fileExt));
               }
                    reader.Close();
                    connect.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               connect.Close();
            }
         }
         return messages;
      }
   }
}
