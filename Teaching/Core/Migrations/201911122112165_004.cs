namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercise1", "Student_ID", "dbo.Students");
            DropIndex("dbo.Exercise1", new[] { "Student_ID" });
            CreateTable(
                "dbo.Exercise21",
                c => new
                    {
                        ID = c.Guid(nullable: false, defaultValueSql: "NEWID()"),
                        Number = c.Int(nullable: false),
                        Principle_ID = c.Guid(nullable: false),
                        Student_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Principles", t => t.Principle_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Principle_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Principles",
                c => new
                    {
                        ID = c.Guid(nullable: false, defaultValueSql: "NEWID()"),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Exercise1", "Student_ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Exercise1", "Student_ID");
            AddForeignKey("dbo.Exercise1", "Student_ID", "dbo.Students", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise1", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Exercise21", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Exercise21", "Principle_ID", "dbo.Principles");
            DropIndex("dbo.Exercise21", new[] { "Student_ID" });
            DropIndex("dbo.Exercise21", new[] { "Principle_ID" });
            DropIndex("dbo.Exercise1", new[] { "Student_ID" });
            AlterColumn("dbo.Exercise1", "Student_ID", c => c.Guid());
            DropTable("dbo.Principles");
            DropTable("dbo.Exercise21");
            CreateIndex("dbo.Exercise1", "Student_ID");
            AddForeignKey("dbo.Exercise1", "Student_ID", "dbo.Students", "ID");
        }
    }
}
