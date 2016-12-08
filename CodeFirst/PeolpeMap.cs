using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace CodeFirst
{
    public class PeolpeMap:EntityTypeConfiguration<People>
    {
        public PeolpeMap()
        {
            this.HasKey(m => m.id);
            this.Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }

    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.HasKey(m => m.id);
            this.Property(m => m.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
          ;

        }
    }
}
