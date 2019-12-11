namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 7),
                        Name = c.String(nullable: false, maxLength: 127),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Chairs", "FacultyID", c => c.Guid());
            CreateIndex("dbo.Chairs", "FacultyID");
            AddForeignKey("dbo.Chairs", "FacultyID", "dbo.Faculties", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chairs", "FacultyID", "dbo.Faculties");
            DropIndex("dbo.Chairs", new[] { "FacultyID" });
            DropColumn("dbo.Chairs", "FacultyID");
            DropTable("dbo.Faculties");
        }
    }
}
