namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspDotnetValidation3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Sales", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "Remarks", c => c.String(nullable: false));
            AlterColumn("dbo.Purchases", "InvoiceNo", c => c.String(nullable: false));
            AlterColumn("dbo.Purchases", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "ContactPerson", c => c.String());
            AlterColumn("dbo.Suppliers", "Contact", c => c.String());
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.Suppliers", "Code", c => c.String());
            AlterColumn("dbo.Purchases", "Code", c => c.String());
            AlterColumn("dbo.Purchases", "InvoiceNo", c => c.String());
            AlterColumn("dbo.PurchaseDetails", "Remarks", c => c.String());
            AlterColumn("dbo.Sales", "Code", c => c.String());
            AlterColumn("dbo.Customers", "Contact", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Code", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Code", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
