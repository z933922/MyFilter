using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernate
{
    /// <summary>
    ///  人的实体对象
    /// </summary>
    [Serializable]
  public    class People
    {

        public virtual int id { set; get; }

        public virtual int age { set; get; }

        public virtual string name { set; get; }

      

    }
}
