using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW.HRDb.DataAnotations.Models
{
    public class HrDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"DataBase=EmployeeDbDataAnotation;Trusted_Connection=True");
        }
    }
}
