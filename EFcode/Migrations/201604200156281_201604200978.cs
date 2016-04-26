namespace EFcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201604200978 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "isshabi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "isshabi", c => c.Boolean(nullable: false));
        }
    }
}
