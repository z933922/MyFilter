using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFcode
{
   public  class PeopleMap:EntityTypeConfiguration<People>
    {
       public PeopleMap()
       {
           this.HasKey(c => c.Id);
           this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           //this.Property(c => c.isshabi).IsRequired();
       }
    }
}
