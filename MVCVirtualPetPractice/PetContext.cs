using Microsoft.EntityFrameworkCore;
using MVCVirtualPetPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVirtualPetPractice
{
    public class PetContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=JenEMVCPets;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                new Pet() { Id = 1, Name = "Roscoe", Description = "What a lazy dog!"},
                new Pet() { Id = 2, Name = "Biggs", Description = "He gets his name because he loves to eat."},
                new Pet() { Id = 3, Name = "Bella", Description = "Bella looks tough, but she's a scaredy cat."}
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
