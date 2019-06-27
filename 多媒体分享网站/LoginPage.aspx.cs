using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;
namespace 多媒体分享网站
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlHelper.Connect();



            VideoDao dao = Factory.Get(new VideoDao());
         List<VideoModel> list=(List<VideoModel>)dao.GetAll();
           
        }

    
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text== "请输入用户名")
            {
                string script = "<script> alert('用户名不能为空！') </script>";
                Page.RegisterStartupScript("", script);
                return;
            }
            if (TextBox2.Text == "请输入密码")
            {
                string script = "<script> alert('密码不能为空！') </script>";
                Page.RegisterStartupScript("", script);
                return;
            }
            string id = TextBox1.Text;
            string password = TextBox2.Text;
            UserDAO dao= Factory.Get(new UserDAO());
            List<UserModel> user=  (List<UserModel>)dao.GetBy("where id='" + id + "'");
            if (user.Count > 0)//ID不存在
            {
                if (user[0].password==password)
                {
                    Session["user"] = user[0];
                    if (user[0].type=="manager")
                        Server.Transfer("ManagerPage.aspx");
                    else
                    Server.Transfer("MainPage.aspx");
                }
                else
                {
                    string script = "<script> alert('密码错误！') </script>";
                    Page.RegisterStartupScript("", script);
                }
            }
            else
            {
                string script = "<script> alert('用户名不存在！') </script>";
                Page.RegisterStartupScript("", script);
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");



        }

        
    }
}