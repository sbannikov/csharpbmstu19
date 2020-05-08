namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoleID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Exercise1",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Code = c.String(),
                        Ability1_ID = c.Guid(),
                        Ability2_ID = c.Guid(),
                        Character_ID = c.Guid(),
                        Role_ID = c.Guid(),
                        Student_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Abilities", t => t.Ability1_ID)
                .ForeignKey("dbo.Abilities", t => t.Ability2_ID)
                .ForeignKey("dbo.Characters", t => t.Character_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Ability1_ID)
                .Index(t => t.Ability2_ID)
                .Index(t => t.Character_ID)
                .Index(t => t.Role_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Family = c.String(maxLength: 255),
                        Group = c.String(maxLength: 16),
                        FileNumber = c.String(),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercise1", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Exercise1", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Exercise1", "Character_ID", "dbo.Characters");
            DropForeignKey("dbo.Exercise1", "Ability2_ID", "dbo.Abilities");
            DropForeignKey("dbo.Exercise1", "Ability1_ID", "dbo.Abilities");
            DropForeignKey("dbo.Abilities", "RoleID", "dbo.Roles");
            DropIndex("dbo.Exercise1", new[] { "Student_ID" });
            DropIndex("dbo.Exercise1", new[] { "Role_ID" });
            DropIndex("dbo.Exercise1", new[] { "Character_ID" });
            DropIndex("dbo.Exercise1", new[] { "Ability2_ID" });
            DropIndex("dbo.Exercise1", new[] { "Ability1_ID" });
            DropIndex("dbo.Abilities", new[] { "RoleID" });
            DropTable("dbo.Students");
            DropTable("dbo.Exercise1");
            DropTable("dbo.Characters");
            DropTable("dbo.Roles");
            DropTable("dbo.Abilities");
        }
    }
}
