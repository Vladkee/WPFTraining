﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCoreEntity.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"DataBase=ShopDb;Trusted_Connection=True;");
        }
    }
}
