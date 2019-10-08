namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            // Задано значение по умолчанию
            AddColumn("dbo.Students", "Mark", c => c.Boolean(nullable: false, defaultValue:false));
            // Изменение существующих столбцов
            AlterColumn("dbo.Abilities", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Characters", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "Family", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "Group", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Students", "FileNumber", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Students", "FileNumber", c => c.String());
            AlterColumn("dbo.Students", "Group", c => c.String(maxLength: 16));
            AlterColumn("dbo.Students", "Family", c => c.String(maxLength: 255));
            AlterColumn("dbo.Characters", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Roles", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Abilities", "Name", c => c.String(maxLength: 255));
            DropColumn("dbo.Students", "Mark");
        }
    }
}
