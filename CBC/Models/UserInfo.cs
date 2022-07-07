using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.Models
{
    public class UserInfo
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Key { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }

        public UserInfo()
        {
            this.FistName = "";
            this.LastName = "";
            this.UserName = "";
            this.Key = "";
            this.Password = "";
            this.Access = 0;
        }

        public UserInfo(string fistName, string lastName, string userName, string key, string password, int access)
        {
            FistName = fistName;
            LastName = lastName;
            UserName = userName;
            Key = key;
            Password = password;
            Access = access;
        }
    }
}
