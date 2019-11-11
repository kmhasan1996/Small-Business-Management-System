using System.Data.Entity;
using DotNetForever.Model.Model;

namespace DotNetForever.DatabaseContext.DatabaseContext
{
    public class SMSDbContext:DbContext
    {
        public object customers;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        
    }
}
