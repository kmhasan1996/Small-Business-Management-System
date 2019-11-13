namespace DotNetForever.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetForever.DatabaseContext.DatabaseContext.SMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DotNetForever.DatabaseContext.DatabaseContext.SMSDbContext";
        }

        protected override void Seed(DotNetForever.DatabaseContext.DatabaseContext.SMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
