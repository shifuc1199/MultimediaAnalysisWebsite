using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 多媒体分享网站.Model;
using System.Data;
namespace 多媒体分享网站.DB
{
    public class YesDAO : DAO
    {
        public Result Delete(object o)
        {
            if (!(o is YesModel))
            {
                return Result.Failed;
            }

            YesModel yes = o as YesModel;

            return SqlHelper.ExcuteNonQuery("delete  from yes where video_id='" + yes.video_id + "' and user_id='"+yes.user_id+"'");
        }

        public object GetAll()
        {
            return GetBy("");
        }

        public object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from yes " + where);

            List<YesModel> yes_list = new List<YesModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                yes_list.Add(new YesModel(table.Rows[i]["video_id"].ToString(), table.Rows[i]["user_id"].ToString()));
            }
            return yes_list;
        }

        public Result Insert(object o)
        {
            if (!(o is YesModel))
            {
                return Result.Failed;
            }

            YesModel video = o as YesModel;
            string sql = "insert into yes values ('" + video.video_id + "','" + video.user_id+ "')";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public Result Update(object o)
        {
            //if (!(o is YesModel))
            //{
            //    return Result.Failed;
            //}
            return Result.Failed;
            //YesModel user = o as YesModel;

            //return SqlHelper.ExcuteNonQuery("update  yes set video_id='" + user.video_id + "'," + "user_id='" + user.user_id +  "' where video_id='"+user.video_id);
        }
    }
}