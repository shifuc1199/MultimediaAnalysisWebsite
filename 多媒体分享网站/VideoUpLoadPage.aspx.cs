using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Data;
using System.IO;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;

namespace 多媒体分享网站
{
    public partial class VideoUpLoadPage : System.Web.UI.Page
    {
        TableRow _last_row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel user = (UserModel)Session["user"];
            if (user == null)
            {
                Server.Transfer("LoginPage.aspx");
            }
          

            Label3.Text = ((多媒体分享网站.Model.UserModel)Session["user"]).name;
            ShowVideoImage();
        }
        protected void ShowVideoImage()
        {
            VideoDao dao = Factory.Get(new VideoDao());
            List<VideoModel> list = (List<VideoModel>)dao.GetBy("where user_id='"+(Session["user"] as UserModel).id+"'");
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
             Label label = new Label();
                button.Click += (object sender, ImageClickEventArgs e) => {
                    if (model.iscansee)
                    {
                        Session["video"] = model; Response.Redirect("VideoPage.aspx");
                    }
                    else
                    {
                        Server.Transfer("ErrorPage.aspx");
                    }
                };
                Label title =new Label();
               Button delete_button = new Button();
                delete_button.Text = "删除";
                delete_button.CssClass = "del_btn";
                delete_button.Click += (object sender, EventArgs e) => {
                    

                    VideoDao video_dao = Factory.Get(new VideoDao());
                        video_dao.Delete(model);
                        File.Delete(Server.MapPath("~/Video/") + model.video_id);
                        File.Delete(Server.MapPath("~/VideoIcon/") + model.video_id.Split('.')[0] + ".jpg");
                        Server.Transfer("VideoUpLoadPage.aspx");
                    
                  };

                if (model.iscansee)
                {
                    label.Text = "审核已通过";
                   
                }
                else
                {
                     
                    label.Text = "正在审核...";
                   
                }
                title.Text = model.title;
                label.Font.Bold = true;
                title.Font.Size = 15;
                label.Font.Size = 20;
                if (Table1.Rows.Count == 0)
                {
                    _last_row = new TableRow();
                    Table1.Rows.Add(_last_row);
                }

                if (_last_row.Cells.Count < 2)
                {

                    TableCell cell = new TableCell();
                    cell.Controls.Add(button);
                   
                    TableCell cell3 = new TableCell();
                    cell3.Controls.Add(title);
                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(label);
                    TableCell cell2 = new TableCell();
                    cell2.Controls.Add(delete_button);

                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell3);
                    _last_row.Cells.Add(cell1);
                    _last_row.Cells.Add(cell2);
                    
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                }
                else
                {

                    _last_row = new TableRow();
                    TableCell cell = new TableCell();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.Controls.Add(label);
                    cell2.Controls.Add(delete_button);
                    TableCell cell3 = new TableCell();
                    cell3.Controls.Add(title);
                    cell.Controls.Add(button);
                   
                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell3);
                    _last_row.Cells.Add(cell1);
                    _last_row.Cells.Add(cell2);
                 
                    Table1.Rows.Add(_last_row);
                
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                }



            }




        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string file_name =Server.MapPath("")+@"\Video\"+FileUpload1.FileName.Split('.')[0]+"-"+ DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") +".mp4";
            //Response.Write(file_name);
            //FileUpload1.SaveAs(  file_name);
      
            //Tool.CatchImg(FileUpload1.FileName, "240*80","1");
        }
       
        protected void Button1_Click1(object sender, EventArgs e)
        {
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
    }
}