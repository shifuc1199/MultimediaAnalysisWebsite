using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 多媒体分享网站.Model
{
    public class NoModel
    {
        public string video_id;
        public string user_id;
        public NoModel(string v,string u)
        {
            video_id = v;
            user_id = u;
        }
    }
}