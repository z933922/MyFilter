using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFcode
{
    class BlogMap:EntityTypeConfiguration<Blog>
    {
        /// <summary>
        ///   这个就是映射的关系
        /// </summary>
        public BlogMap()
        {
            this.HasKey(m=>m.ID);
            this.Property(m=>m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m=>m.name).IsRequired().HasMaxLength(50);
            this.ToTable("Blog");
        }
    }
}
