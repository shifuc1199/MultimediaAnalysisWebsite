using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;
namespace 多媒体分享网站
{
    public class Tool
    {

        public static string CatchImg(string mappermath,string VideoName,string Size, string CutTimeFrame)
        {

           string video_path= mappermath + "Video\\" + VideoName;
            string ffmpeg = mappermath+"ffmpeg.exe";//ffmpeg执行文件的路径
            string PicName = mappermath+"VideoIcon\\" + VideoName.Split('.')[0] + ".jpg";//视频图片的名字，绝对路径

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -i " + video_path
                                + " -y -f image2 -ss " + CutTimeFrame
                                + " -t 0.001 " +"-s "+Size+" "
                                 + PicName;  //設定程式執行參數
            try
            {
                System.Diagnostics.Process.Start(startInfo);
                Thread.Sleep(2000);//线程挂起，等待ffmpeg截图完毕
            }
            catch (Exception)
            {
                return "失败 异常";
            }

            //返回视频图片完整路径
            if (System.IO.File.Exists(PicName))
                return PicName;

            return "失败";


        }
    }

    }