using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public class User
    {
        private string ip;
        private int userID = -1;
        private string username;

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

        public bool IsValidated
        {
            get
            {
                return (userID != null);
            }
        }

        public string IPAddress
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
    }
}
