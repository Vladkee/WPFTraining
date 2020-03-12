using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_DAL.Model
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=StudentAppDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
