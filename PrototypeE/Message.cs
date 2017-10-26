using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrototypeD
{
    [Serializable]
    class Message
    {
        public string command;
        public string name;
        public string message;

        //Need a blank constructor for JSON deserialization
        public Message() { }

        public Message(string command, string name, string message)
        {
            this.command = command;
            this.name = name;
            this.message = message;
        }

        public Message(byte[] Json)
        {
            var jsonString = Encoding.ASCII.GetString(Json);
            var tempMes = JsonConvert.DeserializeObject<Message>(jsonString);
            this.command = tempMes.command;
            this.name = tempMes.name;
            this.message = tempMes.message;
        }

        public byte[] ToJsonBytes()
        {
            var temp = JsonConvert.SerializeObject(this);
            byte[] bytes = Encoding.ASCII.GetBytes(temp);
            return bytes;
        }
    }
}
