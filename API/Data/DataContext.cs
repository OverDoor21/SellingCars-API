using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

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

          modelBuilder.Entity<User>(u =>{
            u.HasMany(l => l.Lots)
            .WithOne(u => u.User)
            .HasForeignKey(k => k.UserId)
            .IsRequired();

          });

          modelBuilder.Entity<Lot>(l => {
            l.HasMany(p => p.Photos)
            .WithOne(l => l.Lot)
            .HasForeignKey(l => l.LotId)
            .IsRequired();

            l.HasOne(r => r.Region)
            .WithMany()
            .HasForeignKey(k => k.RegionId)
            .IsRequired();

            l.HasOne(t => t.TechnicalCondition)
            .WithMany()
            .HasForeignKey(p => p.TechnicalConditionId)
            .IsRequired();

            l.HasOne(i => i.CategoryCar)
            .WithMany()
            .HasForeignKey(b => b.CategoryId)
            .IsRequired();

            l.HasOne(c => c.Car)
            .WithOne(l => l.Lot)
            .HasForeignKey<Lot>(l => l.CarId)
            .IsRequired(false);  
            
            l.HasOne(d => d.Description)
            .WithOne(l => l.Lot)
            .HasForeignKey<Lot>(d => d.DescriptionId )
            .IsRequired(false);  
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