using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using University.DAL.Models;

namespace University.DAL
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=UniversityDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
