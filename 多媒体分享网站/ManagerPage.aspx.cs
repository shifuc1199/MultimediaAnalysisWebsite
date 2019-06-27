using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 多媒体分享网站.DB;
using System.IO;
using 多媒体分享网站.Model;
namespace 多媒体分享网站
{
    public partial class ManagerPage : System.Web.UI.Page
    {
        TableRow _last_row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel user = (UserModel)Session["user"];
            if (user == null)
            {
                Server.Transfer("LoginPage.aspx");
            }
            Label6.Text = user.name;

            ShowVideoImage();
        }
        protected void ShowVideoImage()
        {
            VideoDao dao = Factory.Get(new VideoDao());
            List<VideoModel> list = (List<VideoModel>)dao.GetAll();
        
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
                Label label = new Label();
                Button see_button = new Button();
                title_user.Text = model.title + "<br>上传者:" + model.user_id;
                Button delete_button = new Button();
                delete_button.Text = "删除";
                delete_button.Click += (object sender, EventArgs e) => {
                    
                    VideoDao video_dao = Factory.Get(new VideoDao());
                        video_dao.Delete(model);
                        File.Delete(Server.MapPath("~/Video/") + model.video_id);
                        File.Delete(Server.MapPath("~/VideoIcon/") + model.video_id.Split('.')[0] + ".jpg");
                        Server.Transfer("ManagerPage.aspx");
                   
                };
                if (model.iscansee)
                {
                    label.Text = "审核已通过";
                    see_button.Text = "已审核";
                    see_button.Enabled = false;
                }
                else
                {
                    label.Text = "未审核";
                    see_button.Text = "审核";
                }
                    see_button.Click += (object sender, EventArgs e) => { model.iscansee = true; VideoDao video_dao = Factory.Get(new VideoDao()); video_dao.Update(model); label.Text = "审核已通过";
                    see_button.Text = "已审核";
                    see_button.Enabled = false;
                };
                see_button.Height = 50;
                see_button.Width = 80;
                delete_button.Height = 50;
                delete_button.Width = 80;
                label.Font.Bold = true;
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
                    TableCell cell4 = new TableCell();
                    cell4.Controls.Add(title_user);
                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(label);
                    TableCell cell2 = new TableCell();
                    cell1.Controls.Add(label);
                    cell2.Controls.Add(see_button);
                    cell2.Controls.Add(delete_button);
                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell4);
                    _last_row.Cells.Add(cell1);
                    _last_row.Cells.Add(cell2);
                     
                    cell1.HorizontalAlign = HorizontalAlign.Center;
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
                    TableCell cell4 = new TableCell();
                    cell4.Controls.Add(title_user);
                    cell2.Controls.Add(see_button);
                    cell2.Controls.Add(delete_button);
                    cell.Controls.Add(button);
                    _last_row.Cells.Add(cell);
                    _last_row.Cells.Add(cell4);
                    _last_row.Cells.Add(cell1);
                    _last_row.Cells.Add(cell2);
                    Table1.Rows.Add(_last_row);
                    cell1.HorizontalAlign = HorizontalAlign.Center;
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                }



            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx");
        }
    }
}