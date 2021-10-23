using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.DAL.Models;
using Project.Models;

namespace Project
{
    public class RailDBContext : DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Defect>().Property(u => u.IsDeleted).HasDefaultValue(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
                 
        }

        public DbSet<Defect> Defects { get; set; }
        public DbSet<GlobalSection> GlobalSections { get; set; }
        public DbSet<LocalSection> LocalSections { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DefectAudit> DefectAudits { get; set; }
        public DbSet<Defectoscope> Defectoscopes { get; set; }
        public DbSet<Operator> Operators { get; set; }

       
    }
}
