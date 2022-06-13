using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MVCBasics.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            );

            modelBuilder.Entity<Language>().HasData(

                new Language() { LanguageId = -1, Name = "Swedish" },
                new Language() { LanguageId = -2, Name = "Norwegian" }


           
            );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage { PersonId = -1, LanguageId = -1 },
                new PersonLanguage { PersonId = -2, LanguageId = -1 },
                new PersonLanguage { PersonId = -3, LanguageId = -1 },
                new PersonLanguage { PersonId = -1, LanguageId = -2 },
                new PersonLanguage { PersonId = -3, LanguageId = -2 },
                new PersonLanguage { PersonId = -4, LanguageId = -2 }

            );

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                .HasMany(c => c.People)
                .WithOne(c => c.PersonCity)
                .OnDelete(DeleteBehavior.Cascade);

            //Koppling mellan tabeller city people mm...
            modelBuilder.Entity<PersonLanguage>()
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);

            string adminRoleId = Guid.NewGuid().ToString();
            string StandardRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {
                Id = adminRoleId,
                Name = AccountTypes.Administrator,
                NormalizedName = AccountTypes.AdministratorNormalized });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { 
                Id = StandardRoleId,
                Name = AccountTypes.Standard,
                NormalizedName = AccountTypes.StandardNormalized });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password")

            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });

        }
    }
}
