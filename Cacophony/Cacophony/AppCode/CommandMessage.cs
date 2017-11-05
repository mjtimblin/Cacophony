using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public enum CommandType {Test, ValidateAttempt, ValidateConfirm};

    [Serializable]
    public class CommandMessage : Message
    {
        public CommandType type;

        public string content;

        public CommandMessage(int userID, CommandType type, string content) : base(userID)
        {
            this.type = type;
            this.content = content;
        }
    }
}
