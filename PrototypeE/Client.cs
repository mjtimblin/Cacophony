using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeD
{
    class Client
    {
        private string IP;
        private string userID;
        private string alias;
        private bool validated = false;

        public bool isValidated
        {
            get { return validated; }
            set { validated = value; }
        }

        public Client(string IP)
        {
            this.IP = IP;
        }

        public void SetCredentials(string userID)
        {

        }
    }
}
