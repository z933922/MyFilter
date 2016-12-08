using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myconsole
{
    public class AdoNetUserInfoDal : IService
    {
        public void Show()
        {
            Console.WriteLine("我是 AdoNet Dal" );
        }
    }


    public class EFUserInfoDal : IService
    {
        public void Show()
        {
            Console.WriteLine("我是EF Dal");
        }
    }
}
