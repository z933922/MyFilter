using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Tclass<T>
    {
        public Tclass()
        {
            //IUnityContainer parentContainer = new UnityContainer();
            status = 0;
        }
        public int status{set; get;}

        public T data { set; get; }
    }
}
