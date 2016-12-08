using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcode
{
   public  class BlogEnties:DbContext
    {
       public BlogEnties()
           : base("name=JJ_DBEntities")
       {
       }
        public DbSet<Blog> blosgs { set; get; }
        public DbSet<People> Peoples { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new PeopleMap());
            //AutoMapper
            base.OnModelCreating(modelBuilder);
        }
    }


    
}
