using Microsoft.EntityFrameworkCore;
using Shop.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DAL.Context
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=PracticeShopDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
