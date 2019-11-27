namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "GroupID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Students", "GroupID");
            // Запрет каскадного удаления студентов при удалении группы
            AddForeignKey("dbo.Students", "GroupID", "dbo.Groups", "ID", cascadeDelete: false);
            DropColumn("dbo.Students", "GroupNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "GroupNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "GroupID", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "GroupID" });
            DropColumn("dbo.Students", "GroupID");
        }
    }
}
