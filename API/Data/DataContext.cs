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

        //   modelBuilder.Entity<Car>(car =>
        //     {
        //         car.HasKey(c => c.CarId);
        //     });

          modelBuilder.Entity<Lot>(lot =>{
                lot.HasMany(p => p.Photos)
                .WithOne(l => l.Lot)
                .HasForeignKey(l => l.LotId);

               lot.HasOne(l => l.Car)
                .WithOne(c => c.Lot)
                .HasForeignKey<Car>(c => c.LotId);

                lot.HasOne(Cat => Cat.CategoryCar)
                .WithMany(l => l.Lots)
                .HasForeignKey(c => c.LotId);

                lot.HasOne(desc => desc.Description)
                .WithOne()
                .HasForeignKey<Lot>(l => l.LotId);

                lot.HasOne(reg => reg.Region)
                .WithMany(l => l.Lots)
                .HasForeignKey(l => l.LotId);

                lot.HasOne(tech => tech.TechnicalCondition)
                .WithMany(l => l.Lots)
                .HasForeignKey(l => l.LotId);
          });

        modelBuilder.Entity<TechnicalCondition>().HasData(
            new { Id = 1, TechnicalCond = "New"},
            new { Id = 2, TechnicalCond = "Old"},
            new { Id = 3, TechnicalCond = "Damaged"},
            new { Id = 4, TechnicalCond = "Without any Damage"}
        );

        modelBuilder.Entity<CategoryCar>().HasData(
            new { Id = 1, Category = "Mini"},
            new { Id = 2, Category = "Small Cars"},
            new { Id = 3, Category = "Medium Cars"},
            new { Id = 4, Category = "Large Cars"},
            new { Id = 5, Category = "Executive Cars"},
            new { Id = 6, Category = "Luxury Cars"},
            new { Id = 7, Category = "Sport Cars"},
            new { Id = 8, Category = "MultiPurpose Cars"},
            new { Id = 9, Category = "Jeeps"}
        );

        modelBuilder.Entity<Region>().HasData(
            new {Id = 1,RagionState = "Greater Poland"},
            new {Id = 2,RagionState = "Kuyavian-Pomeranian"},
            new {Id = 3,RagionState = "Lesser Poland"},
            new {Id = 4,RagionState = "Lodz"},
            new {Id = 5,RagionState = "Lower Silesian"},
            new {Id = 6,RagionState = "Lublin"},
            new {Id = 7,RagionState = "Lubusz"},
            new {Id = 8,RagionState = "Masovian"},
            new {Id = 9,RagionState = "Opole"},
            new {Id = 10,RagionState = "Podlasie"},
            new {Id = 11,RagionState = "Pomeranian"}
        );

        }

        public DataContext(DbContextOptions options) : base(options)
        {
            

        }

        
        
    }
}