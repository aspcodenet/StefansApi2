using Microsoft.EntityFrameworkCore;
using StefansApi2.Models;

namespace StefansApi2.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void MigrateData(){
            dbContext.Database.Migrate();
            SeedData();
            dbContext.SaveChanges();
        }

        public void SeedData() {
            if (!dbContext.SuperHeroes.Any(e=>e.Name == "Thor"))
            {
                dbContext.Add(new SuperHero
                {
                    Name = "Thor",
                    FirstName = "Thor",
                    SurName = "Odinson",
                    City = "Asgard" 
                });
            }
        }

    }
}
