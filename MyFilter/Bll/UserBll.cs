using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFilter.Bll
{
    public class UserBll
    {
        private static UserBll _Instance;

        public static UserBll GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new UserBll();
            }
            return _Instance;
        }
    }
}