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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(

            new Person { PersonId = 1, Name = "Adam Andersson", PhoneNumber = "031445511", City = "Trollhättan" },
            new Person { PersonId = 2, Name = "Bengt Bengtsson", PhoneNumber = "031548422", City = "Göteborg" },
            new Person { PersonId = 3, Name = "Cesar Cederquist", PhoneNumber = "031443433", City = "Stockholm" },
            new Person { PersonId = 4, Name = "David Dalquist", PhoneNumber = "0314434242", City = "Göteborg" }

                );
        }
    }
}
