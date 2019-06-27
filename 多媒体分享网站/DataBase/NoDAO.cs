using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using 多媒体分享网站.Model;
namespace 多媒体分享网站.DB
{
    public class NoDAO:DAO
    {
        public Result Delete(object o)
        {
            if (!(o is NoModel))
            {
                return Result.Failed;
            }

            NoModel yes = o as NoModel;

            return SqlHelper.ExcuteNonQuery("delete  from no where video_id='" + yes.video_id + "' and user_id='" + yes.user_id + "'");
        }

        public object GetAll()
        {
            return GetBy("");
        }

        public object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from no " + where);

            List<NoModel> yes_list = new List<NoModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                yes_list.Add(new NoModel(table.Rows[i]["video_id"].ToString(), table.Rows[i]["user_id"].ToString()));
            }
            return yes_list;
        }

        public Result Insert(object o)
        { 
            if (!(o is NoModel))
            {
                return Result.Failed;
            }

            NoModel video = o as NoModel;
            string sql = "insert into no values ('" + video.video_id + "','" + video.user_id + "')";
            return SqlHelper.ExcuteNonQuery(sql);
        }

        public Result Update(object o)
        {
            //if (!(o is NoModel))
            //{
            //    return Result.Failed;
            //}

            //NoModel user = o as NoModel;
            return Result.Failed;
            //return SqlHelper.ExcuteNonQuery("update  no set video_id='" + user.video_id + "'," + "user_id='" + user.user_id + "'");
        }
    }
}