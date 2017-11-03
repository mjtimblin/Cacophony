using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrototypeE
{
   [Serializable]
   class Message
   {
      public string command;
      public string name;
      public string message;
      public string timestamp;

      //Need a blank constructor for JSON deserialization
      public Message() { }

      public Message(string command, string name, string message, string timestamp)
      {
         this.command = command;
         this.name = name;
         this.message = message;
         this.timestamp = timestamp;
      }

      public Message(byte[] Json)
      {
         var jsonString = Encoding.ASCII.GetString(Json);
         var tempMes = JsonConvert.DeserializeObject<Message>(jsonString);
         this.command = tempMes.command;
         this.name = tempMes.name;
         this.message = tempMes.message;
         this.timestamp = tempMes.timestamp;
      }

      public byte[] ToJsonBytes()
      {
         var temp = JsonConvert.SerializeObject(this);
         byte[] bytes = Encoding.ASCII.GetBytes(temp);
         return bytes;
      }

      public string getChatFormat()
      {
         return "[" + name + " : " + timestamp + "]" + " " + message;
      }
   }
}
