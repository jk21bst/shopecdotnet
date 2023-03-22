namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        deliveryType = c.String(),
                        orderdate = c.DateTime(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        productsPurchased = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ShoppingCarts", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        refernceno = c.String(),
                        userId = c.Int(nullable: false),
                        active = c.Boolean(nullable: false),
                        expiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ShoppingCartDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        ShoppingCartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ShoppingCartId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        usertype = c.String(),
                        address = c.String(),
                        city = c.String(),
                        zip = c.Int(nullable: false),
                        state = c.String(),
                        emailAddress = c.String(),
                        phoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartDetails", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.ShoppingCartDetails", new[] { "ShoppingCartId" });
            DropIndex("dbo.Orders", new[] { "id" });
            DropTable("dbo.Users");
            DropTable("dbo.ShoppingCartDetails");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Orders");
        }
    }
}
