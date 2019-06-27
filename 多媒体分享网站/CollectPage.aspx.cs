using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;

namespace 多媒体分享网站
{
    public partial class CollectPage : System.Web.UI.Page
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
            CollectDAO collect_dao = Factory.Get(new CollectDAO());
        List< CollectModel> collect= (List<CollectModel>)collect_dao.GetBy("where user_id='" + (Session["user"] as UserModel).id + "'");
            VideoDao dao = Factory.Get(new VideoDao());
            List<VideoModel> list = new List<VideoModel>();
            foreach (var item in collect)
            {
                List<VideoModel> m = (List<VideoModel>)dao.GetBy("where video_id='"+item.video_id+"'");
                list.Add(m[0]);
            }
          

            foreach (VideoModel model in list)
            {
                System.Windows.Forms.ListViewItem item1 = new System.Windows.Forms.ListViewItem();
                //之前是直接用Images.FromFile(string Path)从文件夹中读取，删除时没法删除
                //改从文件流中读取图片，关闭窗口时可以删除文件

                string image_path = "VideoIcon/" + model.video_id.Split('.')[0] + ".jpg";

                ImageButton button = new ImageButton();
                button.Height = 100;
                button.Width = 160;
                button.ImageUrl = image_path;
                Label title_user = new Label();
                button.Click += (object sender, ImageClickEventArgs e) => { Session["video"] = model; Response.Redirect("VideoPage.aspx"); };
                title_user.Text = model.title + "<br>上传者:" + model.user_id;
            

                if (Table1.Rows.Count == 0)
                {
                    _last_row = new TableRow();
                    Table1.Rows.Add(_last_row);
                }

                if (_last_row.Cells.Count < 2)
                {

                    TableCell cell = new TableCell();
                    cell.Controls.Add(button);
                    TableCell cell4 = new TableCell();
                    cell4.Controls.Add(title_user);
                   
               
                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell4);
                   

                
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    
                }
                else
                {

                    _last_row = new TableRow();
                    TableCell cell = new TableCell();
                   
                
                    TableCell cell4 = new TableCell();
                    cell4.Controls.Add(title_user);
               
                    cell.Controls.Add(button);
                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell4);
                
                 
                    Table1.Rows.Add(_last_row);
                   
                    cell.HorizontalAlign = HorizontalAlign.Center;
                  
                }



            }




        }
        protected void Mainpage(object sender, EventArgs e)
        {
            Server.Transfer("MainPage.aspx");
        }
        protected void Tougao(object sender, EventArgs e)
        {


            Response.Redirect("VideoUpLoadPage.aspx");
        }
        protected void Shoucang(object sender, EventArgs e)
        {


            Response.Redirect("CollectPage.aspx");
        }

        protected void Tuichu(object sender, EventArgs e)
        {

            Session["user"] = null;
            Server.Transfer("LoginPage.aspx");
        }
    }
}