namespace Shopec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "shoppingCartId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "shoppingCartId");
        }
    }
}
