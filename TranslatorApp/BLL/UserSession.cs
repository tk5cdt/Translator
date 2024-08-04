using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserSession
    {
        private static UserSession instance = null;
        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserSession();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public UserSession() { }
        public string Username { get; private set; }
        public int Uid { get; private set; }

        public void SetUsername(string username)
        {
            Username = username;
        }
        public void SetUid(int uid)
        {
            Uid = uid;
        }


    }
}
