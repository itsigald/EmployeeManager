using EM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Job = EM.Domain.Entities.Job;

namespace EM.Data
{
    public class EMContext : DbContext
    {
        
        public EMContext(DbContextOptions<EMContext> options) : base(options)
        {
            var k = options;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string dbPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../", "EM.Data", "em-database.db"));

        //    optionsBuilder.UseSqlite($"Filename={dbPath}", options =>
        //    {
        //        options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        //    });

        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=NOTEBOOK-HP\\SQLEXPRESS;Database=EmployeeManager;Integrated Security=true;Trust Server Certificate=True;");
        //}

        public DbSet<Employee> Employess { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<Job> Tasks { get; set; } = default!;
        public DbSet<Report> Reports { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerId);
        }
    }
}
