namespace EFcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201604200952 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "isshabi", c => c.Boolean(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Name", c => c.String());
            DropColumn("dbo.People", "isshabi");
        }
    }
}
