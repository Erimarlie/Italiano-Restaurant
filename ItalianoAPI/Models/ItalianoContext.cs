using Microsoft.EntityFrameworkCore;

namespace ItalianoAPI.Models {
     public class ItalianoContext : DbContext {
         
         public ItalianoContext(DbContextOptions<ItalianoContext> options):base(options) {}

         public DbSet<FoodMenu> FoodMenu { get; set; }
         public DbSet<FoodInfo> FoodInfo { get; set; }
         public DbSet<FoodRatings> FoodRatings { get; set; }

         public DbSet<DrinkMenu> DrinkMenu { get; set; }
         public DbSet<DrinkInfo> DrinkInfo { get; set; }
         public DbSet<DrinkRatings> DrinkRatings { get; set; }

         public DbSet<DessertMenu> DessertMenu { get; set; }
         public DbSet<DessertInfo> DessertInfo { get; set; }
         public DbSet<DessertRatings> DessertRatings { get; set; }

     }
}