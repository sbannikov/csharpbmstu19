namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Groups", "Chair_ID", c => c.Guid());
            CreateIndex("dbo.Groups", "Chair_ID");
            AddForeignKey("dbo.Groups", "Chair_ID", "dbo.Chairs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Chair_ID", "dbo.Chairs");
            DropIndex("dbo.Groups", new[] { "Chair_ID" });
            DropColumn("dbo.Groups", "Chair_ID");
            DropTable("dbo.Chairs");
        }
    }
}
