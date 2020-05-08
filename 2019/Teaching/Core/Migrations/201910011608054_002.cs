namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeRows",
                c => new
                {
                    ID = c.Guid(nullable: false, defaultValueSql: "NEWID()"),
                    Number = c.Int(nullable: false),
                    Row = c.Int(nullable: false),
                    Version = c.Int(nullable: false),
                    Code = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.CodeRows");
        }
    }
}
