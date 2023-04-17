using Microsoft.EntityFrameworkCore;
using TuesdayAlphaApi.Models;
namespace TuesdayAlphaApi.Data
{
     public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Monthly> MonthlyEvents { get; set; }
        public DbSet<OneTimeEvent> OneTimeEvents { get; set; }
        public DbSet<ParentCity> ParentCities { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Weekly> WeeklySpecials { get; set; }
    }
}