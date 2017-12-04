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
    }
}
