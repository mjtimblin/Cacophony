using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    [Serializable]
    public abstract class Message
    {
        protected int messageID;
        protected DateTime postDate;
        protected int userID;
        protected string userAlias;
        protected bool isPinned = false;

        public Message(int userID, string userAlias)
        {
            this.userID = userID;
            this.postDate = DateTime.UtcNow;
            this.userAlias = userAlias;
        }

        public Message(int userID, string userAlias, int messageID, DateTime postDate)
        {
            this.userID = userID;
            this.postDate = postDate;
            this.messageID = messageID;
            this.userAlias = userAlias;
        }

        public bool IsPinned
        {
            get
            {
                return isPinned;
            }
            set
            {
                isPinned = value;
            }
        }

        public int MessageID
        {
            get
            {
                return messageID;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }
        }

        public DateTime PostDate
        {
            get
            {
                return postDate;
            }
        }

        public string UserAlias
        {
            get
            {
                return userAlias;
            }
        }

        public byte[] SerializeMessage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static Message DeserializeMessage(byte[] message)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(message, 0, message.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var mes = (Message)binForm.Deserialize(memStream);
            return mes;
        }
    }
}
