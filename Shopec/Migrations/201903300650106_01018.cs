namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "id", "dbo.ShoppingCarts");
            DropIndex("dbo.Orders", new[] { "id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Orders", "id");
            AddForeignKey("dbo.Orders", "id", "dbo.ShoppingCarts", "id");
        }
    }
}
