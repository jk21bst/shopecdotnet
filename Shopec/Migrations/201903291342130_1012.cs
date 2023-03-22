namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1012 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "id" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "id");
            CreateIndex("dbo.Orders", "id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "id" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "id");
            CreateIndex("dbo.Orders", "id");
        }
    }
}
