using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    [Serializable]
    public class TextMessage : Message
    {
        private string content;
        public TextMessage(int userID, string content) : base(userID)
        {
            this.content = content;
        }

        public TextMessage(int userID, int textID, DateTime postDate, string content) : base(userID, textID, postDate)
        {
            this.content = content;
        }

        public string Content
        {
            get
            {
                return content;
            }
        }
    }
}
