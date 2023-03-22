namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1011 : DbMigration
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
            AlterColumn("dbo.Orders", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "id");
            CreateIndex("dbo.Orders", "id");
        }
    }
}
