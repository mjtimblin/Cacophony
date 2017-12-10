using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public enum CommandType {Test, ValidateAttempt, ValidateConfirm, Ping, CloseConnection, RequestMessages,
        Promote, Demote, Lock, SetPassword, SetDisplayName, Ban, DeleteMessage, Pin, SetGroupAnnouncements, CloseServer};

    [Serializable]
    public class CommandMessage : Message
    {
        public CommandType type;

        public object content;

        public CommandMessage(int userID, string userAlias, CommandType type, object content) : base(userID, userAlias)
        {
            this.type = type;
            this.content = content;
        }
    }
}
