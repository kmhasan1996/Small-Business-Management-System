namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatetype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FoodItemId", "dbo.FoodItems");
            DropForeignKey("dbo.Members", "MemberTypeId", "dbo.MemberTypes");
            DropForeignKey("dbo.Orders", "MemberId", "dbo.Members");
            DropIndex("dbo.Orders", new[] { "FoodItemId" });
            DropIndex("dbo.Orders", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "MemberTypeId" });
            AddColumn("dbo.Sales", "DiscountPercentage", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "DateTime", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.PurchaseDetails", "ManufacturedDateTime", c => c.DateTime(nullable: false, storeType: "date"));
            DropTable("dbo.FoodItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Members");
            DropTable("dbo.MemberTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberTypeId = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodItemId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.PurchaseDetails", "ManufacturedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sales", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sales", "DiscountPercentage");
            CreateIndex("dbo.Members", "MemberTypeId");
            CreateIndex("dbo.Orders", "MemberId");
            CreateIndex("dbo.Orders", "FoodItemId");
            AddForeignKey("dbo.Orders", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Members", "MemberTypeId", "dbo.MemberTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "FoodItemId", "dbo.FoodItems", "Id", cascadeDelete: true);
        }
    }
}
