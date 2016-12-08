using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDLL
{
    public class MyService : IMyService
    {
     public  static List<Contact> Mylist;

        static MyService()
        {
            Mylist = new List<Contact>
     {
                    new Contact { Id = "001", Name = "张三", PhoneNo = "123", EmailAddress = "zhangsan@gmail.com" },
                    new Contact { Id = "002", Name = "李四", PhoneNo = "456", EmailAddress = "lisi@gmail.com" }
      };
        }


        public List<Contact> GetList()
        {
            return Mylist;
        }
    }
}
