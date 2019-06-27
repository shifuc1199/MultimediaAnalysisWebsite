using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 多媒体分享网站.DB
{
    public interface  DAO
    {
        Result Insert(object o);
        Result Update(object o);
        Result Delete(object o);
          object GetBy(string where);
          object GetAll();

    }
}