namespace Bmstu.IU6.Teaching.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Mark", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Mark");
        }
    }
}
