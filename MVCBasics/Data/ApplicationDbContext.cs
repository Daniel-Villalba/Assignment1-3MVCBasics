using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;

namespace MVCBasics.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Sweden" },
                new Country() { Id = 2, Name = "Norway" }
                );

            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Gothenburg", CountryId = 1 },
                new City() { Id = 2, Name = "Stockholm", CountryId = 1 },
                new City() { Id = 3, Name = "Malmoe", CountryId = 1 },
                new City() { Id = 4, Name = "Oslo", CountryId = 2 },
                new City() { Id = 5, Name = "Bergen", CountryId = 2 }
            );


            modelBuilder.Entity<Person>().HasData(

                new Person(-1, "Adam Andersson", "+4631445511",1),
                new Person (-2, "Bengt Bengtsson", "+4631548422", 1),
                new Person (-3, "Cesar Cederquist", "+4731443433", 4),
                new Person (-4,"David Dalquist", "+47314434242", 5)

                //Koppling mellan tabeller city people mm...
            );
            
        }
    }
}
