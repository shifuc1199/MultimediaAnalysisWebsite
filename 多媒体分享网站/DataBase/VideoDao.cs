using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 多媒体分享网站.Model;
using System.Data;
namespace 多媒体分享网站.DB
{
    public class VideoDao : DAO
    {
        public Result Delete(object o)
        {
            if (!(o is VideoModel))
            {
                return Result.Failed;
            }

            VideoModel video = o as VideoModel;

            return SqlHelper.ExcuteNonQuery("delete  from video where video_id='" + video.video_id + "'");

        }

        public object GetAll()
        {
            return GetBy("");
        }

        public object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from video " + where);

            List<VideoModel> video_list = new List<VideoModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                video_list.Add(new VideoModel(table.Rows[i]["video_id"].ToString(), table.Rows[i]["title"].ToString(), table.Rows[i]["url"].ToString(), table.Rows[i]["user_id"].ToString(), table.Rows[i]["des"].ToString(), int.Parse(table.Rows[i]["iscansee"].ToString())==0?false:true, int.Parse( table.Rows[i]["yes"].ToString()), int.Parse(table.Rows[i]["no"].ToString()), int.Parse(table.Rows[i]["collect"].ToString())));
            }
            return video_list;
        }

        public Result Insert(object o)
        {
            if (!(o is VideoModel))
            {
                return Result.Failed;
            }

            VideoModel video = o as VideoModel;
            string sql = "insert into video values ('" + video.video_id + "','" + video.title + "','" + video.des + "','" + video.user_id + "'," + video.iscansee + ","  + video.yes + "," + video.no + ","  + video.collect  +",'" +video.url+"')";
            return SqlHelper.ExcuteNonQuery(sql );
        }

        public Result Update(object o)
        {
            if (!(o is VideoModel))
            {
                return Result.Failed;
            }

            VideoModel video = o as VideoModel;
            string sql = "update  video set video_id='" + video.video_id + "'," + "title='" + video.title + "',url='" + video.url + "',iscansee=" + video.iscansee + ",yes=" + video.yes + ",no=" + video.no + ",collect=" + video.collect + " where video_id=" + "'" + video.video_id + "'";
            return SqlHelper.ExcuteNonQuery(sql );
        }
    }
}