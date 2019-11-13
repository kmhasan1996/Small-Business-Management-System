namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseAndSaleTable13330 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SaleDetail_Id", "dbo.SaleDetails");
            DropForeignKey("dbo.Products", "PurchaseDetail_Id", "dbo.PurchaseDetails");
            DropIndex("dbo.Products", new[] { "SaleDetail_Id" });
            DropIndex("dbo.Products", new[] { "PurchaseDetail_Id" });
            DropColumn("dbo.Products", "SaleDetail_Id");
            DropColumn("dbo.Products", "PurchaseDetail_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PurchaseDetail_Id", c => c.Int());
            AddColumn("dbo.Products", "SaleDetail_Id", c => c.Int());
            CreateIndex("dbo.Products", "PurchaseDetail_Id");
            CreateIndex("dbo.Products", "SaleDetail_Id");
            AddForeignKey("dbo.Products", "PurchaseDetail_Id", "dbo.PurchaseDetails", "Id");
            AddForeignKey("dbo.Products", "SaleDetail_Id", "dbo.SaleDetails", "Id");
        }
    }
}
