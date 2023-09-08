using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Photo> Photos {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-KPNDRJ8;Initial Catalog=CarShop;Integrated Security=True;TrustServerCertificate=True;",
                x => x.UseDateOnlyTimeOnly());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<User>()
          .HasOne(u => u.Photo)
          .WithOne(p => p.User)
          .HasForeignKey<Photo>(p => p.UserId);

        }

        public DataContext(DbContextOptions options) : base(options)
        {
          

        }

        
        
    }
}