namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseAndSaleTable133 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Purchases", "SupplierId");
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
        }
    }
}
