using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 多媒体分享网站.Model;
using System.Data;
namespace 多媒体分享网站.DB
{
    public class CollectDAO:DAO
    {
        public Result Delete(object o)
        {
            if (!(o is CollectModel))
            {
                return Result.Failed;
            }

            CollectModel yes = o as CollectModel;

            return SqlHelper.ExcuteNonQuery("delete  from collect where video_id='" + yes.video_id + "' and user_id='" + yes.user_id + "'");
        }

        public object GetAll()
        {
            return GetBy("");
        }

        public object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from collect " + where);

            List<CollectModel> yes_list = new List<CollectModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                yes_list.Add(new CollectModel(table.Rows[i]["video_id"].ToString(), table.Rows[i]["user_id"].ToString()));
            }
            return yes_list;
        }

        public Result Insert(object o)
        {
            if (!(o is CollectModel))
            {
                return Result.Failed;
            }

            CollectModel video = o as CollectModel;
            string sql = "insert into collect values ('" + video.video_id + "','" + video.user_id + "')";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public Result Update(object o)
        {
            //if (!(o is CollectModel))
            //{
            //    return Result.Failed;
            //}
            return Result.Failed;
            //CollectModel user = o as CollectModel;

            //return SqlHelper.ExcuteNonQuery("update  collect set video_id='" + user.video_id + "'," + "user_id='" + user.user_id + "'");
        }
    }
}