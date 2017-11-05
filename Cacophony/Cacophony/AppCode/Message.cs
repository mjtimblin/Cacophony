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

        protected DateTime timestamp;

        protected int userID;

        public Message(int userID)
        {
            this.userID = userID;
            this.timestamp = DateTime.UtcNow;
        }

        public Message(int userID, int messageID, DateTime timestamp)
        {
            this.userID = userID;
            this.timestamp = timestamp;
            this.messageID = messageID;
        }

        public int UserID
        {
            get
            {
                return userID;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return timestamp;
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
