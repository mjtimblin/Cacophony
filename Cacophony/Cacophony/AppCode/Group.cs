using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    public class Group
    {
        private int groupID;
        private string groupName;
        private string password;
        private bool isLocked = false;
        private int port;
        private List<int> moderators = new List<int>();
        private int owner;//Might change

        public Group(int groupID, string groupName, string password, int port, int owner)
        {
            this.groupID = groupID;
            this.groupName = groupName;
            this.password = password;
            this.port = port;
            this.owner = owner;
        }

        public Group(int groupID, string groupName, string password, List<int> moderators, int owner)
        {
            this.groupID = groupID;
            this.groupName = groupName;
            this.password = password;
            this.moderators = moderators;
            this.owner = owner;
        }

        public int GroupID
        {
            get
            {
                return groupID;
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public bool IsLocked
        {
            get
            {
                return isLocked;
            }
            set
            {
                isLocked = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
        }

        public List<int> Moderators
        {
            get
            {
                return moderators;
            }
        }

        public void AddModerator(int user)
        {
            if (!moderators.Contains(user))
                moderators.Add(user);
        }

        public void RemoveModerator(int user)
        {
            moderators.Remove(user);//Should work...
        }

        public int Owner
        {
            get
            {
                return owner;
            }
        }
    }
}
