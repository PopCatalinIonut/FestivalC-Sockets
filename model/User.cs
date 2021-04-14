using System;
using System.Runtime.Serialization;

namespace festival.model
{
    [Serializable]
    public class User : Entity<String>
    {
        private String user, passwd;
        public User(string username, string password) {
            user = username;
            passwd = password;
        }
        
        public string password
        {
            get { return passwd; }
            set{ passwd = value;}
        
        }

        public string username
        {
            get { return user; }
            set { user = value;}
       
        }
        
    }
}