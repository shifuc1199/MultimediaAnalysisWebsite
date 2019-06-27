using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 多媒体分享网站.Model
{
    public class UserModel
    {
        public string id;
        public string password;
        public string name;
        public string type;
        public UserModel(string i,string p,string n,string t)
        {
            type = t;
            id = i;
            password = p;
            name = n;
        }
    }
}