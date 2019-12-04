namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Chairs", "Number", unique: true, name: "IX_NUMBER");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Chairs", "IX_NUMBER");
        }
    }
}
