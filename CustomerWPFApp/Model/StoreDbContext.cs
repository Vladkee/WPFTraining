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
            // Relationships.
            //

            modelBuilder.Entity<Order>()
                .HasOne(s => s.Store)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            //
            // Naming.
            //

            modelBuilder.Entity<Staff>()
                .ToTable("staffs", "sales")
                .Property(p => p.StaffId)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Staff>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Staff>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Staff>()
                .Property(p => p.IsActive)
                .HasColumnName("active");
            modelBuilder.Entity<Staff>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Staff>()
                .Property(p => p.ManagerId)
                .HasColumnName("manager_id")
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .ToTable("orders", "sales")
                .Property(p => p.OrderId)
                .HasColumnName("order_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderStatus)
                .HasColumnName("order_status");
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderDate)
                .HasColumnName("order_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.RequiredDate)
                .HasColumnName("required_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.ShippedDate)
                .HasColumnName("shipped_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.StaffId)
                .HasColumnName("staff_id");

            modelBuilder.Entity<OrderItem>()
                .ToTable("orders_items", "sales")
                .Property(p => p.OrderId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Discount)
                .HasColumnName("discount");

            modelBuilder.Entity<Store>()
                .ToTable("stores", "sales")
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Store>()
                .Property(p => p.StoreName)
                .HasColumnName("store_name");
            modelBuilder.Entity<Store>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Store>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Store>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Store>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Store>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Store>()
                .Property(p => p.ZipCode)
                .HasColumnName("zip_code");

            modelBuilder.Entity<Customer>()
                .ToTable("customers", "sales")
                .Property(p => p.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Customer>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Customer>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Customer>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Customer>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Customer>()
                .Property(p => p.ZipCode)
                .HasColumnName("zip_code");

            modelBuilder.Entity<Stock>()
                .ToTable("stocks", "production")
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");

            modelBuilder.Entity<Product>()
                .ToTable("products", "production")
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasColumnName("product_name");
            modelBuilder.Entity<Product>()
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ModelYear)
                .HasColumnName("model_year");
            modelBuilder.Entity<Product>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");

            modelBuilder.Entity<Category>()
                .ToTable("categories", "production")
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .HasColumnName("category_name");

            modelBuilder.Entity<Brand>()
                .ToTable("brands", "production")
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Brand>()
                .Property(p => p.BrandName)
                .HasColumnName("brand_name");

            //
            // Keys.
            //

            modelBuilder.Entity<OrderItem>().HasKey(k => new { k.OrderId, k.ProductId });
            modelBuilder.Entity<Stock>().HasKey(k => new { k.StoreId, k.ProductId });

            //
            // Database seeding.
            //

            modelBuilder.Entity<Staff>().HasData(
                new Staff()
                {
                    StaffId = 1,
                    FirstName = "Vlad",
                    LastName = "Radchenko",
                    Email = "vlad@gmail.com",
                    Phone = "+380990527544",
                    IsActive = true,
                    StoreId = 1,
                    ManagerId = null
                },
                new Staff()
                {
                    StaffId = 2,
                    FirstName = "Roman",
                    LastName = "Sokolenko",
                    Email = "roman@gmail.com",
                    Phone = "+380506447544",
                    IsActive = true,
                    StoreId = 1,
                    ManagerId = 1
                },
                new Staff()
                {
                    StaffId = 3,
                    FirstName = "Andrey",
                    LastName = "Fedorchenko",
                    Email = "andrey@gmail.com",
                    Phone = "+380993349763",
                    IsActive = true,
                    StoreId = 2,
                    ManagerId = 1
                },
                new Staff()
                {
                    StaffId = 4,
                    FirstName = "Tanya",
                    LastName = "Ryzyk",
                    Email = "tanya@gmail.com",
                    Phone = "+380991144267",
                    IsActive = true,
                    StoreId = 2,
                    ManagerId = 1
                });

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    CustomerId = 1,
                    OrderStatus = "Delivered",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 1,
                    StaffId = 1
                },
                new Order()
                {
                    OrderId = 2,
                    CustomerId = 1,
                    OrderStatus = "Delivered",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 1,
                    StaffId = 2
                },
                new Order()
                {
                    OrderId = 3,
                    CustomerId = 2,
                    OrderStatus = "On Holding",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 2,
                    StaffId = 3
                },
                new Order()
                {
                    OrderId = 4,
                    CustomerId = 2,
                    OrderStatus = "On Holding",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 2,
                    StaffId = 4
                });

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem()
                {
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 20,
                    ListPrice = 500.00m,
                    Discount = null
                },
                new OrderItem()
                {
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 30,
                    ListPrice = 100.00m,
                    Discount = 10
                },
                new OrderItem()
                {
                    OrderId = 3,
                    ProductId = 3,
                    Quantity = 100,
                    ListPrice = 1000.00m,
                    Discount = 5
                },
                new OrderItem()
                {
                    OrderId = 4,
                    ProductId = 4,
                    Quantity = 66,
                    ListPrice = 350.00m,
                    Discount = null
                });

            modelBuilder.Entity<Store>().HasData(
                new Store()
                {
                    StoreId = 1,
                    StoreName = "North Shop",
                    Phone = "+380578445793",
                    Email = "n.shop@gmail.com",
                    Street = "Shevchenko, 14",
                    City = "Kyiv",
                    State = "Default",
                    ZipCode = "55483"
                },
                new Store()
                {
                    StoreId = 2,
                    StoreName = "South Shop",
                    Phone = "+380578445790",
                    Email = "s.shop@gmail.com",
                    Street = "Naukova, 20",
                    City = "Kharkiv",
                    State = "Default",
                    ZipCode = "61111"
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    CustomerId = 1,
                    FirstName = "Nikolay",
                    LastName = "Fedko",
                    Phone = "+380665338211",
                    Email = "fedko@gmail.com",
                    Street = "Nekimora, 101",
                    City = "Odesa",
                    State = "Default",
                    ZipCode = "51095"
                },
                new Customer()
                {
                    CustomerId = 2,
                    FirstName = "Dmitriy",
                    LastName = "Pelepa",
                    Phone = "+380661125312",
                    Email = "pepela@gmail.com",
                    Street = "Svetlaya, 101",
                    City = "Lviv",
                    State = "Default",
                    ZipCode = "41111"
                },
                new Customer()
                {
                    CustomerId = 3,
                    FirstName = "Oleg",
                    LastName = "Reshetilo",
                    Phone = "+380501460586",
                    Email = "boy777@gmail.com",
                    Street = "Zernovaya, 85",
                    City = "Kharkiv",
                    State = "Default",
                    ZipCode = "61194"
                },
                new Customer()
                {
                    CustomerId = 4,
                    FirstName = "Alexey",
                    LastName = "Kasatkin",
                    Phone = "+380663110984",
                    Email = "kasat@gmail.com",
                    Street = "Akademika, 1",
                    City = "Kharkiv",
                    State = "Default",
                    ZipCode = "61095"
                });

            modelBuilder.Entity<Stock>().HasData(
                new Stock()
                {
                    StoreId = 1,
                    ProductId = 1,
                    Quantity = 50
                },
                new Stock()
                {
                    StoreId = 1,
                    ProductId = 2,
                    Quantity = 25
                },
                new Stock()
                {
                    StoreId = 2,
                    ProductId = 3,
                    Quantity = 100
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "IPhone X",
                    BrandId = 1,
                    CategoryId = 1,
                    ModelYear = 2018,
                    ListPrice = 20000.00m
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "IPhone 8",
                    BrandId = 1,
                    CategoryId = 1,
                    ModelYear = 2018,
                    ListPrice = 15000.00m
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "IPhone 7",
                    BrandId = 1,
                    CategoryId = 1,
                    ModelYear = 2017,
                    ListPrice = 10000.00m
                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Notebook 15",
                    BrandId = 2,
                    CategoryId = 2,
                    ModelYear = 2018,
                    ListPrice = 21000.00m
                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Butterfly 19",
                    BrandId = 3,
                    CategoryId = 2,
                    ModelYear = 2015,
                    ListPrice = 17000.00m
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Phone"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Notebook"
                });

            modelBuilder.Entity<Brand>().HasData(
                new Brand()
                {
                    BrandId = 1,
                    BrandName = "Apple"
                },
                new Brand()
                {
                    BrandId = 2,
                    BrandName = "ASUS"
                },
                new Brand()
                {
                    BrandId = 3,
                    BrandName = "Acer"
                });
        }
    }
}