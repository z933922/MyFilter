using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    [Table("People")]
    public class People
    {

        [Key]
        public int id { set; get; }

        //[ForeignKey("id")]
        //public virtual Student student { set; get; }

        
        public int StudentId { set; get; }

       


        public virtual Student stu { set; get; }
    }
}
