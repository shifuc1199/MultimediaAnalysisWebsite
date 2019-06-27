using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;
namespace 多媒体分享网站
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            string password = TextBox2.Text;
            string name = TextBox3.Text;
            UserModel user = new UserModel(id, password, name,"user");
            UserDAO dao = Factory.Get(new UserDAO());
            List<UserModel> id_list= (List<UserModel>)dao.GetBy("where id='" + id + "'");
            List<UserModel> name_list = (List<UserModel>)dao.GetBy("where name='" + name + "'");
            if (id=="请输入用户名"||password=="请输入密码"||name== "请输入姓名")
            {
                string script = "<script> alert('信息不能为空！') </script>";
                Page.RegisterStartupScript("", script);
                 
            }
            else if(id_list.Count>0)
            {
                string script = "<script> alert('注册失败！用户名已存在') </script>";
                Page.RegisterStartupScript("", script);
            }
            else if(name_list.Count>0)
            {
                string script = "<script> alert('注册失败！姓名已存在') </script>";
                Page.RegisterStartupScript("", script);
            }
            else
            {
                Result result = dao.Insert(user);
                if (result == Result.Successful)
                {


                    string script = "<script> alert('注册成功！'); window.location.href='LoginPage.aspx'; </script>";
                    Page.RegisterStartupScript("", script);





                }
                else
                {
                    string script = "<script> alert('注册失败！发生未知错误！') </script>";
                    Page.RegisterStartupScript("", script);
                }
            }
        }
         
    }
}