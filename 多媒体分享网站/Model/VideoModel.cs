using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 多媒体分享网站.Model
{
    public class VideoModel
    {
        public string title;
        public string url;
        public string video_id;
        public string des;
        public string user_id;
        public bool iscansee;
        public int yes;
        public int no;
        public int collect;
       
        public VideoModel(string id,string t,string u,string user_id,string des="")
        {
            this.des = des;
            this.video_id = id;
            this.title = t;
            this.url = u;
            this.user_id = user_id;
        }

        public VideoModel(string id, string t, string u, string user_id, string des="",bool iscansee=false,int yes=0,int no=0,int collect=0)
        {
            this.des = des;
            this.video_id = id;
            this.title = t;
            this.url = u;
            this.user_id = user_id;
            this.yes = yes;
            this.no = no;
            this.collect = collect;
            this.iscansee = iscansee;
        }
    }
}