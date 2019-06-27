using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 多媒体分享网站.Model
{
    public class CommentModel
    {
       
            public string video_id;
            public string user_id;
        public string contenct;
            public CommentModel(string v, string u,string c)
            {
             contenct = c;
                video_id = v;
                user_id = u;
            }
       
    }
}