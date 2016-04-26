namespace EFcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "code");
        }
    }
}
