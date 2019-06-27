using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using 多媒体分享网站.DB;
using 多媒体分享网站.Model;
using System.Web.SessionState;
namespace 多媒体分享网站
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
           
            HttpPostedFile file = context.Request.Files["file"];
            string uploadPath = HttpContext.Current.Server.MapPath("~/Video/");

            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
              
                string name = System.Guid.NewGuid().ToString() + ".mp4";

                string video_title = context.Request["video_title"];
                string video_des   = context.Request["video_des"];
                string user_id   = context.Request["user_id"];
                VideoModel video = new VideoModel(name, video_title,  "\\\\Video\\\\"+name, user_id, video_des);
                VideoDao dao = Factory.Get(new VideoDao());
                dao.Insert(video);
                file.SaveAs(uploadPath + name);
                Tool.CatchImg(HttpContext.Current.Server.MapPath("../"), name, "240*180", "1");
                
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}