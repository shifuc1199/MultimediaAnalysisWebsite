using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using 多媒体分享网站.Model;
namespace 多媒体分享网站.DB
{
    public class UserDAO :DAO
    {
        public Result Delete(object o)
        {
            if (!(o is UserModel))
            {
                return Result.Failed;
            }

            UserModel user = o as UserModel;

            return SqlHelper.ExcuteNonQuery("delete  from user where id='"+user.id+"'");
        }

        public object GetAll()
        {
            return GetBy("");
        }

        public  object GetBy(string where)
        {
            DataTable table = SqlHelper.ExcuteQuery("select * from user "+where);

            List<UserModel> user_list = new List<UserModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                user_list.Add(new UserModel(table.Rows[i]["id"].ToString(), table.Rows[i]["password"].ToString(), table.Rows[i]["name"].ToString(),table.Rows[i]["type"].ToString())); 
            }
            return user_list;
        }

        public Result Insert(object o)
        {
            if(!(o is UserModel))
            {
                return Result.Failed;
            }

            UserModel user =  o as UserModel;

            return SqlHelper.ExcuteNonQuery("insert into user values ('"+user.id+"','"+user.password+"','"+user.name+"','"+user.type+"')");
        }

        public Result Update(object o)
        {
            if (!(o is UserModel))
            {
                return Result.Failed;
            }

            UserModel user = o as UserModel;

            return SqlHelper.ExcuteNonQuery("update  user set id='"+user.id+"',"+"password='"+user.password+"',name='"+user.name+"',type='"+user.type+"' where id="+ "'" + user.id +"'");
        }
    }
}