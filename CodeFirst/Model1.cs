namespace CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {

        }

        public DbSet<People> dbpeople { set; get; }
        public DbSet<Student> dbStudent { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeolpeMap());
            modelBuilder.Configurations.Add(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
