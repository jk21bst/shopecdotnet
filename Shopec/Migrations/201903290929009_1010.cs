namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1010 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCartDetails", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.ShoppingCartDetails", new[] { "ShoppingCartId" });
            RenameColumn(table: "dbo.ShoppingCartDetails", name: "ShoppingCartId", newName: "shoppingCartId_id");
            AlterColumn("dbo.ShoppingCartDetails", "shoppingCartId_id", c => c.Int());
            CreateIndex("dbo.ShoppingCartDetails", "shoppingCartId_id");
            AddForeignKey("dbo.ShoppingCartDetails", "shoppingCartId_id", "dbo.ShoppingCarts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartDetails", "shoppingCartId_id", "dbo.ShoppingCarts");
            DropIndex("dbo.ShoppingCartDetails", new[] { "shoppingCartId_id" });
            AlterColumn("dbo.ShoppingCartDetails", "shoppingCartId_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ShoppingCartDetails", name: "shoppingCartId_id", newName: "ShoppingCartId");
            CreateIndex("dbo.ShoppingCartDetails", "ShoppingCartId");
            AddForeignKey("dbo.ShoppingCartDetails", "ShoppingCartId", "dbo.ShoppingCarts", "id", cascadeDelete: true);
        }
    }
}
