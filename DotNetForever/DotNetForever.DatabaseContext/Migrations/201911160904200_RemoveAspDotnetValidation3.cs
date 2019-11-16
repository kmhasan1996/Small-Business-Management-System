namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAspDotnetValidation3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Code", c => c.String());
        }
    }
}
