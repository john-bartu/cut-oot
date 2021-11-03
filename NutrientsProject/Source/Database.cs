using Microsoft.EntityFrameworkCore;

namespace NutrientsProject.Source
{
    public class Database : DbContext
    {


        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<NutrientProduct> NutrientProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseMySQL("server=mysql0.small.pl;database=m1139_nutrients;user=m1139_dietetic;password=Nutrients2021");
            optionsBuilder.UseNpgsql("Host=localhost;Database=p1139_nutrients;Username=p1139_nutrients;Password=Nutrients2021");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

                  

        }
    }

}
