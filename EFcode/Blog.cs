using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcode
{
   public  class Blog
    {
       [Key]
       public int ID { set; get; }

        public string name{set;get;}


        public string title { set; get; }

        public string code { set; get; }
    }
}
