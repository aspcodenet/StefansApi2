using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using StefansApi2.Models;

namespace StefansApi2.Data
{
    public class ApplicationDbContext : DbContext​
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}