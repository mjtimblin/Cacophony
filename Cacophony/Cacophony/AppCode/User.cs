using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public class User
    {
        private int userID;
        private string alias;
        private string pin;

        public User(int userID, string alias, string pin)
        {
            this.userID = userID;
            this.alias = alias;
            this.pin = pin;
        }

        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
            }
        }

        public string PIN
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }
    }
}
