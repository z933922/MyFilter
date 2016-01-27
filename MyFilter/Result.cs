using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFilter
{
    public class Result<T>
    {
        public int Isok { set; get; }
        public string Message { set; get; }

        public T Data{set; get;}
    }
}