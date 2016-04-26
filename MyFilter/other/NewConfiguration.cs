using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EFcode;

namespace MyFilter.other
{
    public class NewConfiguration : DbMigrationsConfiguration<BlogEnties>
    {
        public NewConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogEnties context)
        {
            
            base.Seed(context);
        }
    }
}