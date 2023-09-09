using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Photo> Photos {get;set;}
        public DbSet<Car> Cars {get;set;}
        public DbSet<CategoryCar> Categories {get;set;}
        public DbSet<Description> Descriptions {get;set;}
        public DbSet<Lot> Lots{get;set;}
        public DbSet<Region> Regions {get;set;}
        public DbSet<TechnicalCondition> TechnicalConditions {get;set;}
        

        //Applies a Ext of DateTimeOnly for EF without this you cant work with dataTimeOnly
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-KPNDRJ8;Initial Catalog=CarShop;Integrated Security=True;TrustServerCertificate=True;",
                x => x.UseDateOnlyTimeOnly());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<User>(user =>
          {
            user.HasOne(u => u.Photo)
            .WithOne(p => p.User)
            .HasForeignKey<Photo>(p => p.UserId);

            user.HasMany(l => l.Lots)
                .WithOne(user => user.User)
                .HasForeignKey(l => l.UserId);
          });

          modelBuilder.Entity<Lot>(lot =>{
                lot.HasMany(p => p.Photos)
                .WithOne(l => l.Lot)
                .HasForeignKey(l => l.LotId);

                //Дописать отношения для всех моделей которые были созданы
                
               

          });



        }

        public DataContext(DbContextOptions options) : base(options)
        {
            

        }

        
        
    }
}