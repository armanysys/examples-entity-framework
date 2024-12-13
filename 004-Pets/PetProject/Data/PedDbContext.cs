using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetProject.Models;

namespace PetProject.Data
{
    public class PedDbContext : DbContext
    {
        private readonly string? connectionString;
        public DbSet<Species> Species { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public PedDbContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Pet");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Species
            modelBuilder.Entity<Species>().HasData(
                new Species { Id = 1, Name = "Dog" },
                new Species { Id = 2, Name = "Cat" },
                new Species { Id = 3, Name = "Bird" }
            );

            // Seed data for Owners
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Name = "John Doe" },
                new Owner { Id = 2, Name = "Jane Smith" }
            );

            // Seed data for Breeds
            modelBuilder.Entity<Breed>().HasData(
                new Breed { Id = 1, Name = "Labrador", SpeciesId = 1 },
                new Breed { Id = 2, Name = "Beagle", SpeciesId = 1 },
                new Breed { Id = 3, Name = "Siamese", SpeciesId = 2 },
                new Breed { Id = 4, Name = "Persian", SpeciesId = 2 },
                new Breed { Id = 5, Name = "Parrot", SpeciesId = 3 },
                new Breed { Id = 6, Name = "Canary", SpeciesId = 3 }
            );

            // Seed data for Pets
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Buddy", Age = 3, Weight = 20.5m, SpeciesId = 1, BreedId = 1 },
                new Pet { Id = 2, Name = "Max", Age = 2, Weight = 18.0m, SpeciesId = 1, BreedId = 2 },
                new Pet { Id = 3, Name = "Bella", Age = 4, Weight = 22.0m, SpeciesId = 1, BreedId = 1 },
                new Pet { Id = 4, Name = "Charlie", Age = 1, Weight = 15.0m, SpeciesId = 1, BreedId = 2 },
                new Pet { Id = 5, Name = "Lucy", Age = 5, Weight = 10.0m, SpeciesId = 2, BreedId = 3 },
                new Pet { Id = 6, Name = "Molly", Age = 3, Weight = 12.0m, SpeciesId = 2, BreedId = 4 },
                new Pet { Id = 7, Name = "Daisy", Age = 2, Weight = 11.0m, SpeciesId = 2, BreedId = 3 },
                new Pet { Id = 8, Name = "Luna", Age = 1, Weight = 9.0m, SpeciesId = 2, BreedId = 4 },
                new Pet { Id = 9, Name = "Coco", Age = 2, Weight = 0.5m, SpeciesId = 3, BreedId = 5 },
                new Pet { Id = 10, Name = "Polly", Age = 3, Weight = 0.6m, SpeciesId = 3, BreedId = 5 },
                new Pet { Id = 11, Name = "Tweety", Age = 1, Weight = 0.4m, SpeciesId = 3, BreedId = 6 },
                new Pet { Id = 12, Name = "Sunny", Age = 2, Weight = 0.5m, SpeciesId = 3, BreedId = 6 }
            );
        }
    }
}
