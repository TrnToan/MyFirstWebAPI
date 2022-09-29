using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

// This directory is going to have everything we need to access the database, such as repositories implementations.
namespace Supermarket.API.Domain.Persistence.Contexts
{
    // DbContext is a class EF Core uses to map your models to database tables
    // implement the database context class first
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        // constructor passes the database configuration to the base class through dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // OnModelCreating map the models’ properties to the respective table columns 
        // specifying which properties are primary keys, which are foreign keys, the column types, etc
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);   // Set the primary key
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            // add two example categories by default
            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Dairy" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );
        }
    }
}