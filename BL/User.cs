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
        public string UserName;
        public string avatar;
        public int totalCash;
        public int score;
        public int league;

        public User(string id, string name, string avatar, int totalCash,int score,int league)
        {
            this.ID = id;
            this.UserName = name;
            this.avatar = avatar;
            this.totalCash = totalCash;
            this.score = score;
            this.league = league;
        }

        public User(string id, string name) {

            this.ID = id;
            this.UserName = name;
        }
    }
}
