using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using 多媒体分享网站.Model;
namespace 多媒体分享网站.DB
{
    public class CommentDAO:DAO
    {
        public Result Delete(object o)
        {
            if (!(o is CommentModel))
            {
                return Result.Failed;
            }

            CommentModel yes = o as CommentModel;

            return SqlHelper.ExcuteNonQuery("delete  from comment where video_id='" + yes.video_id + "' and user_id='" + yes.user_id + "'");
        }

        public object GetAll()
        {
            return GetBy("");
        }

        public object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from comment " + where);

            List<CommentModel> yes_list = new List<CommentModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                yes_list.Add(new CommentModel(table.Rows[i]["video_id"].ToString(), table.Rows[i]["user_id"].ToString(), table.Rows[i]["contenct"].ToString()));
            }
            return yes_list;
        }

        public Result Insert(object o)
        {
            if (!(o is CommentModel))
            {
                return Result.Failed;
            }

            CommentModel video = o as CommentModel;
            string sql = "insert into comment values ('" + video.video_id + "','" + video.user_id +"','"+video.contenct+ "')";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public Result Update(object o)
        {
            if (!(o is CommentModel))
            {
                return Result.Failed;
            }

            CommentModel user = o as CommentModel;

            return SqlHelper.ExcuteNonQuery("update  comment set contenct='"+user.contenct+"' where video_id='"+user.video_id+"' and user_id='"+user.user_id+"'");
        }
    }
}