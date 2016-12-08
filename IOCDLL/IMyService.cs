using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDLL
{
    public  interface IMyService
    {
        List<Contact> GetList();
    }
}
