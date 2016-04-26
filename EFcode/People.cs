using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EFcode
{
   public class People
    {
        [Key]
       public int Id { set; get;}

       [Required,MaxLength(20)]
       public string Name { set; get; }

       public int Age { set; get; }

    
    }
}
