namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseAndSaleTable1333 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SaleDetail_Id", c => c.Int());
            AddColumn("dbo.Products", "PurchaseDetail_Id", c => c.Int());
            CreateIndex("dbo.Products", "SaleDetail_Id");
            CreateIndex("dbo.Products", "PurchaseDetail_Id");
            CreateIndex("dbo.Sales", "CustomerId");
            CreateIndex("dbo.SaleDetails", "ProductId");
            CreateIndex("dbo.PurchaseDetails", "ProductId");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SaleDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SaleDetail_Id", "dbo.SaleDetails", "Id");
            AddForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "PurchaseDetail_Id", "dbo.PurchaseDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PurchaseDetail_Id", "dbo.PurchaseDetails");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SaleDetail_Id", "dbo.SaleDetails");
            DropForeignKey("dbo.SaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.SaleDetails", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "PurchaseDetail_Id" });
            DropIndex("dbo.Products", new[] { "SaleDetail_Id" });
            DropColumn("dbo.Products", "PurchaseDetail_Id");
            DropColumn("dbo.Products", "SaleDetail_Id");
        }
    }
}
