using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;

namespace Model
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=ShopDataBase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Naming.
            //

            modelBuilder.Entity<Staff>().ToTable("staffs", "sales")
                .Property(p => p.StaffId).HasColumnName("staff_id");
            modelBuilder.Entity<Staff>().Property(p => p.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<Staff>().Property(p => p.LastName).HasColumnName("last_name");
            modelBuilder.Entity<Staff>().Property(p => p.Email).HasColumnName("email");
            modelBuilder.Entity<Staff>().Property(p => p.Phone).HasColumnName("phone");
            modelBuilder.Entity<Staff>().Property(p => p.IsActive).HasColumnName("active");
            modelBuilder.Entity<Staff>().Property(p => p.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Staff>().Property(p => p.ManagerId).HasColumnName("manager_id");

            modelBuilder.Entity<Order>().ToTable("orders", "sales")
                .Property(p => p.OrderId).HasColumnName("order_id");
            modelBuilder.Entity<Order>().Property(p => p.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Order>().Property(p => p.OrderStatus).HasColumnName("order_status");
            modelBuilder.Entity<Order>().Property(p => p.OrderDate).HasColumnName("order_date");
            modelBuilder.Entity<Order>().Property(p => p.RequiredDate).HasColumnName("required_date");
            modelBuilder.Entity<Order>().Property(p => p.ShippedDate).HasColumnName("shipped_date");
            modelBuilder.Entity<Order>().Property(p => p.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Order>().Property(p => p.StaffId).HasColumnName("staff_id");

            modelBuilder.Entity<OrderItem>().ToTable("orders_items", "sales")
                .Property(p => p.OrderId).HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>().Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>().Property(p => p.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>().Property(p => p.ListPrice).HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>().Property(p => p.Discount).HasColumnName("discount");

            modelBuilder.Entity<Store>().ToTable("stores", "sales")
                .Property(p => p.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Store>().Property(p => p.StoreName).HasColumnName("store_name");
            modelBuilder.Entity<Store>().Property(p => p.Phone).HasColumnName("phone");
            modelBuilder.Entity<Store>().Property(p => p.Email).HasColumnName("email");
            modelBuilder.Entity<Store>().Property(p => p.Street).HasColumnName("street");
            modelBuilder.Entity<Store>().Property(p => p.City).HasColumnName("city");
            modelBuilder.Entity<Store>().Property(p => p.State).HasColumnName("state");
            modelBuilder.Entity<Store>().Property(p => p.ZipCode).HasColumnName("zip_code");

            modelBuilder.Entity<Customer>().ToTable("customers", "sales")
                .Property(p => p.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasColumnName("first_name");
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasColumnName("last_name");
            modelBuilder.Entity<Customer>().Property(p => p.Phone).HasColumnName("phone");
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasColumnName("email");
            modelBuilder.Entity<Customer>().Property(p => p.Street).HasColumnName("street");
            modelBuilder.Entity<Customer>().Property(p => p.City).HasColumnName("city");
            modelBuilder.Entity<Customer>().Property(p => p.State).HasColumnName("state");
            modelBuilder.Entity<Customer>().Property(p => p.ZipCode).HasColumnName("zip_code");

            modelBuilder.Entity<Stock>().ToTable("stocks", "production")
                .Property(p => p.StoreId).HasColumnName("store_id");
            modelBuilder.Entity<Stock>().Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Stock>().Property(p => p.Quantity).HasColumnName("quantity");

            modelBuilder.Entity<Product>().ToTable("products", "production")
                .Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(p => p.BrandId).HasColumnName("brand_id");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Product>().Property(p => p.ModelYear).HasColumnName("model_year");
            modelBuilder.Entity<Product>().Property(p => p.ListPrice).HasColumnName("list_price");

            modelBuilder.Entity<Category>().ToTable("categories", "production")
                .Property(p => p.CategoryId).HasColumnName("category_id");
            modelBuilder.Entity<Category>().Property(p => p.CategoryName).HasColumnName("category_name");

            modelBuilder.Entity<Brand>().ToTable("brands", "production")
                .Property(p => p.BrandId).HasColumnName("brand_id");
            modelBuilder.Entity<Brand>().Property(p => p.BrandName).HasColumnName("brand_name");

            //
            // Keys.
            //

            modelBuilder.Entity<OrderItem>().HasKey(k => new { k.OrderId, k.ProductId });
            modelBuilder.Entity<Stock>().HasKey(k => new { k.StoreId, k.ProductId });
        }
    }
}
