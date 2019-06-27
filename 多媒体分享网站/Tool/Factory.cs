using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace 多媒体分享网站
{
    public class Factory
    {
        public static T Get<T>(T t)
        {

        Type type = t.GetType();
        return (T)type.Assembly.CreateInstance(type.ToString());
           
        }
    }
}