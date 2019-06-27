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
    public partial class VideoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            UserModel user = (UserModel)Session["user"];
            if(user==null)
            {
                Server.Transfer("LoginPage.aspx");
            }
            Label6.Text = user.name;

            VideoDao video_dao = Factory.Get(new VideoDao());
            List<VideoModel> list =(List <VideoModel>)video_dao.GetBy("where video_id='" + (Session["video"] as VideoModel).video_id+"'");
            var title = (Session["video"] as VideoModel).title;
            var des = (Session["video"] as VideoModel).des;
            var yes = list[0].yes;
            var no = list[0].no;
            var collect = list[0].collect;
            Label1.Text = title;
            UserDAO user_dao = Factory.Get(new UserDAO());
            Label2.Text ="上传者:"+ ((List<UserModel>)user_dao.GetBy("where id='"+(Session["video"] as VideoModel).user_id+"'"))[0].name+"<br>"+ des;
            Label3.Text = "赞:" + yes;
            Label4.Text = "收藏:" + collect;
            Label5.Text = "踩:" + no;

            NoDAO nodao = Factory.Get(new NoDAO());
            List<NoModel> no_list = (List<NoModel>)nodao.GetBy("where video_id='" + (Session["video"] as VideoModel).video_id + "' and user_id='" + (Session["user"] as UserModel).id + "'");

            CollectDAO collect_dao = Factory.Get(new CollectDAO());
            List<CollectModel> collect_list = (List<CollectModel>)collect_dao.GetBy("where video_id='" + (Session["video"] as VideoModel).video_id + "' and user_id='" + (Session["user"] as UserModel).id + "'");

            YesDAO dao = Factory.Get(new YesDAO());
            List<YesModel> yes_list=  (List<YesModel>) dao.GetBy("where video_id='"+ (Session["video"] as VideoModel).video_id+"' and user_id='"+(Session["user"] as UserModel).id+"'");
           if(yes_list.Count>0)
            {
                Button2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9"); 
               
            }
            if (no_list.Count > 0)
            {
                Button4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9");

            }
            if (collect_list.Count > 0)
            {
                Button3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9");

            }
            UpdateComment();

            if ((Session["user"] as UserModel).type == "manager")
            {
                tougao.Visible = false;
                shoucang.Visible = false;
                return1.Visible = true;
            }

            else
            {
                tougao.Visible = true;
                shoucang.Visible = true;
                return1.Visible = false;
            }
        }
        protected void UpdateComment()
        {
            CommentDAO dao = Factory.Get(new CommentDAO());
            List<CommentModel> list =(List<CommentModel>) dao.GetBy("where video_id='"+(Session["video"] as VideoModel).video_id+"'");
            foreach (var item in list)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                Label name = new Label();
                Label contenct = new Label();
                UserDAO user_dao = Factory.Get(new UserDAO());
               List<UserModel> user=(List<UserModel>)  user_dao.GetBy("where id='" + item.user_id + "'");
                name.Text = user[0].name+":";
                contenct.Text = "<br>"+item.contenct;
                cell.Height = 80;
                cell.Controls.Add(name);
                cell.Controls.Add(contenct);
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((Session["user"] as UserModel).type == "manager")
                Server.Transfer("ManagerPage.aspx");
            else
            Server.Transfer("MainPage.aspx");
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            YesDAO yes_dao = Factory.Get(new YesDAO());
            VideoModel video_model = (Session["video"] as VideoModel);
            YesModel yes_model = new YesModel(video_model.video_id, (Session["user"] as UserModel).id);
            VideoDao video_dao = Factory.Get(new VideoDao());
            if (Button4.ForeColor == System.Drawing.ColorTranslator.FromHtml("#1763e9") )
            {
                NoDAO no_dao = Factory.Get(new NoDAO());
                NoModel no_model = new NoModel(video_model.video_id, (Session["user"] as UserModel).id);
                Button4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#757575"); 
                no_dao.Delete(no_model);
                video_model.no--;
                Label5.Text = "踩:" + video_model.no;
            }

                if (Button2.ForeColor == System.Drawing.ColorTranslator.FromHtml("#1763e9"))
            {
                Button2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#757575");
                yes_dao.Delete(yes_model);
                video_model.yes--;
            }
            else if (Button2.ForeColor == System.Drawing.ColorTranslator.FromHtml("#757575"))
            {
                Button2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9");
                yes_dao.Insert(yes_model);
                video_model.yes++;
            }


            Label3.Text = "赞:" + video_model.yes;


            video_dao.Update(video_model);
           
        }
        protected void No_Click(object sender, EventArgs e)
        {
            NoDAO no_dao = Factory.Get(new NoDAO());
            VideoModel video_model = (Session["video"] as VideoModel);
            NoModel no_model = new NoModel(video_model.video_id, (Session["user"] as UserModel).id);
            VideoDao video_dao = Factory.Get(new VideoDao());
            if (Button2.ForeColor == System.Drawing.ColorTranslator.FromHtml("#1763e9"))
            {
                YesDAO yes_dao = Factory.Get(new YesDAO());
                YesModel yes_model = new YesModel(video_model.video_id, (Session["user"] as UserModel).id);
               
                Button2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#757575");
                yes_dao.Delete(yes_model);
                video_model.yes--;
                Label3.Text = "赞:" + video_model.yes;
            }
           
                if (Button4.ForeColor == System.Drawing.ColorTranslator.FromHtml("#1763e9"))
            {
                Button4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#757575");
                no_dao.Delete(no_model);
                video_model.no--;
            }
            else if (Button4.ForeColor == System.Drawing.ColorTranslator.FromHtml("#757575"))
            {
                Button4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9");
                no_dao.Insert(no_model);
                video_model.no++;
            }
             


            Label5.Text = "踩:" + video_model.no;


            video_dao.Update(video_model);
        }
        protected void Collect_Click(object sender, EventArgs e)
        {
            CollectDAO yes_dao = Factory.Get(new CollectDAO());
            VideoModel video_model = (Session["video"] as VideoModel);
            CollectModel yes_model = new CollectModel(video_model.video_id, (Session["user"] as UserModel).id);
            VideoDao video_dao = Factory.Get(new VideoDao());

            if (Button3.ForeColor == System.Drawing.ColorTranslator.FromHtml("#1763e9"))
            {
                Button3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#757575");
                yes_dao.Delete(yes_model);
                video_model.collect--;
            }
            else if (Button3.ForeColor == System.Drawing.ColorTranslator.FromHtml("#757575"))
            {
                Button3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1763e9");
                yes_dao.Insert(yes_model);
                video_model.collect++;
            }


            Label4.Text = "收藏:" + video_model.collect;


            video_dao.Update(video_model);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text== "请输入评论")
            {
                string script = "<script> alert('评论不能为空！') </script>";
                Page.RegisterStartupScript("", script);
                return;
            }
            CommentDAO dao = Factory.Get(new CommentDAO());
            CommentModel model = new CommentModel((Session["video"] as VideoModel).video_id, (Session["user"] as UserModel).id,TextBox1.Text);
            dao.Insert(model);
            Server.Transfer("VideoPage.aspx");
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {


            if ((Session["user"] as UserModel).type == "manager")
                Server.Transfer("ManagerPage.aspx");
            else
                Server.Transfer("MainPage.aspx");
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {


            Response.Redirect("CollectPage.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {


            Response.Redirect("VideoUpLoadPage.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

            Session["user"] = null;
            Server.Transfer("LoginPage.aspx");
        }
        protected void Button6_Click1(object sender, EventArgs e)
        {


            if ((Session["user"] as UserModel).type == "manager")
                Server.Transfer("ManagerPage.aspx");
            else
                Server.Transfer("MainPage.aspx");
        }

    }
}