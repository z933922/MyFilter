namespace EFcode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160419 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Blogs", newName: "Blog");
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Blog", "name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blog", "name", c => c.String());
            DropTable("dbo.People");
            RenameTable(name: "dbo.Blog", newName: "Blogs");
        }
    }
}
