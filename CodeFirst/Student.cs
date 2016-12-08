using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{

    [Table("Student")]
 public    class Student
    {

        [Key]
        public int id { set; get; }

        
       


       public  List<People> listpeople { set; get; }

        public string StuName { set; get; }
    }
}
