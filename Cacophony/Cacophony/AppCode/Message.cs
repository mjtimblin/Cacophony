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
        protected int textID;

        protected DateTime postDate;

        protected int userID;

        public Message(int userID)
        {
            this.userID = userID;
            this.postDate = DateTime.UtcNow;
        }

        public Message(int userID, int messageID, DateTime postDate)
        {
            this.userID = userID;
            this.postDate = postDate;
            this.textID = messageID;
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
