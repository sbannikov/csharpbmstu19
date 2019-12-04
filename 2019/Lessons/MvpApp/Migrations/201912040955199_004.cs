namespace MvpApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chairs", "Name", c => c.String
            (
                nullable: false, 
                maxLength: 127,
                defaultValue: "Заполните название кафедры"
            ));
        }

        public override void Down()
        {
            DropColumn("dbo.Chairs", "Name");
        }
    }
}
