using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class User
    {
        public string ID;
        public string password;
        public string UserName;
        public string Email;
        public int totalCash;
        public int score;


        public User(string id, string name, string email, string pass)
        {
            this.ID = id;
            this.UserName = name;
            this.Email = email;
            this.password = pass;
        }
    }
}
