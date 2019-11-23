namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        LoyaltyPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        MRP = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ManufacturedDateTime = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false, storeType: "date"),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        MRP = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Remarks = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false, storeType: "date"),
                        InvoiceNo = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.SaleDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.SaleDetails", new[] { "ProductId" });
            DropIndex("dbo.SaleDetails", new[] { "SaleId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
