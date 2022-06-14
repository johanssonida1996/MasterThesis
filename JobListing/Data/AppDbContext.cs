using JobListing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkTypes> WorkTypes { get; set; }
        public DbSet<WorkTypesWorker> WorkTypesWorker { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FavoriteCartItem> FavoriteCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "IT" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Bygg" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Utvecklare" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Kassabiträde" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Kundtjänst" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 6, CategoryName = "Vård och Omsorg" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 7, CategoryName = "Annat" });

            modelBuilder.Entity<City>().HasData(new City { CityId = 1, CityName = "Stockholm" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, CityName = "Göteborg" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, CityName = "Malmö" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, CityName = "Örebro" });
            modelBuilder.Entity<City>().HasData(new City { CityId = 5, CityName = "Västerrås" });

            modelBuilder.Entity<WorkTypes>().HasData(new WorkTypes { Id = 1, WorkTypesName = "Heltid" });
            modelBuilder.Entity<WorkTypes>().HasData(new WorkTypes { Id = 2, WorkTypesName = "Deltid" });
            modelBuilder.Entity<WorkTypes>().HasData(new WorkTypes { Id = 3, WorkTypesName = "Visstid/Projekt" });
            modelBuilder.Entity<WorkTypes>().HasData(new WorkTypes { Id = 4, WorkTypesName = "Praktik" });
 

            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 11, EducationName = "Gymnasieutbildning" });
            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 12, EducationName = "Universitets- och Högskoleutbildning" });
            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 13, EducationName = "Yrkeshögskoleutbildning" });
            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 14, EducationName = "Komvux / Vuxenutbildning" });
            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 15, EducationName = "Folkhögskoleutbildning" });
            modelBuilder.Entity<Education>().HasData(new Education { EducationId = 16, EducationName = "Kurs eller övrig utbildning" });



        }
    }
}
