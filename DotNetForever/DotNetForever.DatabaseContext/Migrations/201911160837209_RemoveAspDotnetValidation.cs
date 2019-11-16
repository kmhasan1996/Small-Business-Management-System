namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAspDotnetValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ReorderLevel", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Code", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "RecorderLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "RecorderLevel", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ReorderLevel");
        }
    }
}
