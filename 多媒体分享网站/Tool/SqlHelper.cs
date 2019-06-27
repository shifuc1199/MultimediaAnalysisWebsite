using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
namespace 多媒体分享网站
{
  
    public enum Result 
    {
        Failed,
        Successful
    }
    public enum RegisterResult
    {
        NameExist,
        IDExist
    }
    public class SqlHelper
    {
        static string connString = "server=127.0.0.1;database=video_shared_system_database;uid=root;pwd=007088";
        static MySqlConnection conn = new MySqlConnection(connString);
        public static DataTable ExcuteQuery(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static Result ExcuteNonQuery(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, conn);
            try
            {
                int index = command.ExecuteNonQuery();

                if (index == 0)
                    return Result.Failed;
                else
                    return Result.Successful;
            }
            catch  (MySqlException e)
            {
                var a = e.StackTrace;
                return Result.Failed;
            }
            
        }

        
        public static Result Connect()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                return Result.Failed;

            try
            {
             
                conn.Open();
                return Result.Successful;
            }
            catch (MySqlException ex)
            {
                return Result.Failed;
              
            }
             
        }


    }
}