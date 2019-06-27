using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;
 
using System.IO;
namespace 多媒体分享网站
{
    public partial class MainPage : System.Web.UI.Page
    {
        TableRow _last_row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel user = (UserModel)Session["user"];
          
            if (user == null)
            {
                Server.Transfer("LoginPage.aspx");
            }
           
            Label1.Text = user.name;

            ShowVideoImage();
            
           

        }
        protected void ShowVideoImage()
        {
            VideoDao dao = Factory.Get(new VideoDao());
            List<VideoModel> list = (List<VideoModel>)dao.GetAll();

            List<VideoModel> CanSeeVideoList = new List<VideoModel>();
            foreach (var item in list)
            {
                if(item.iscansee)
                {
                    CanSeeVideoList.Add(item);
                }
            }
            foreach (VideoModel model in CanSeeVideoList)
            {
                System.Windows.Forms.ListViewItem item1 = new System.Windows.Forms.ListViewItem();
                //之前是直接用Images.FromFile(string Path)从文件夹中读取，删除时没法删除
                //改从文件流中读取图片，关闭窗口时可以删除文件

                string image_path = "VideoIcon/" + model.video_id.Split('.')[0] + ".jpg";


                ImageButton button = new ImageButton();
                button.Height = 140;
                button.Width =200;
                button.ImageUrl = image_path;
                Label title = new Label();
                button.Click += (object sender, ImageClickEventArgs e) => { Session["video"] = model;   Response.Redirect("VideoPage.aspx"); };
                title.Text ="<br>"+model.title;
                if (Table1.Rows.Count == 0)
                {
                    _last_row = new TableRow();
                    Table1.Rows.Add(_last_row);
                }

                if (_last_row.Cells.Count<5)
                {
 
                TableCell cell = new TableCell();
                cell.Controls.Add(button);
            
                 cell.Controls.Add(title);
                _last_row.Cells.Add(cell);

                }
                else
                {

                    _last_row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Controls.Add(button);
                   
                    cell.Controls.Add(title);
                    _last_row.Cells.Add(cell);
                    Table1.Rows.Add(_last_row);

                }


            }
            if (_last_row != null)
            {
                int index = 5 - _last_row.Cells.Count;
                for (int i = 0; i < index; i++)
                {
                    TableCell cell = new TableCell();
                    Label l = new Label();

                    l.Height = 140;
                    l.Width = 200;
                    cell.Controls.Add(l);
                    _last_row.Cells.Add(cell);
                }
            }
          



        }
        protected void Button3_Click1(object sender, EventArgs e)
        {


            Response.Redirect("CollectPage.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

          
            Response.Redirect ("VideoUpLoadPage.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
         
            Session["user"] = null;
            Server.Transfer("LoginPage.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            Server.Transfer("MainPage.aspx");
        }
    }
}