using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using PetProject.Data;
using PetProject.Models;

namespace PetProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cb = new ConfigurationBuilder();
            cb.AddJsonFile("config.json");
            var config = cb.Build();

            using var db = new PedDbContext(config); 
            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var species = db.Species
                            .Where(s => s.Id == 2)
                            .ToList();
            var pets = db.Pets
                        .Include(p => p.Owners)
                        .ToList();

            var breeds = db.Breeds
                            .Include(b => b.Species)
                            .Select(b => new { BreedName= b.Name, SpeciesName = b.Species.Name })
                            .OrderBy(b => b.SpeciesName)
                            .ThenBy(b=> b.SpeciesName)
                            .ToList();

            foreach (var item in breeds)
            {
                Console.WriteLine($"{item.BreedName} - {item.SpeciesName}");
            }

            //var perro = new Species { Name = "Perro" };
            //var gato = new Species { Name = "Gato" };
            //db.Species.Add(perro);
            //db.Species.Add(gato);
            //db.SaveChanges();

            //var beagle = new Breed() { Name = "Beagle", Species = perro };
            //var pitbull = new Breed() { Name = "Pitbull", SpeciesId = 1 };
            //var siames = new Breed() { Name = "Siames", SpeciesId = 2 };
            //db.Breeds.Add(beagle);
            //db.Breeds.Add(pitbull);
            //db.Breeds.Add(siames);
            //db.SaveChanges();

            //var owner = new Owner() { Name = "Armando" };
            //var armando= new Owner() { Name = "andtoni" };
            //db.Owners.Add(owner);
            //db.Owners.Add(armando);
            //db.SaveChanges();

            //var max = new Pet() { Name = "Max", Breed = beagle };
            //var cati = new Pet() { Name = "pulga", Breed = 2 };
            //max.Owners.Add(owner);
            //cati.Owners.Add(armando);
            //db.Pets.Add(max);
            //db.Pets.Add(cati);
            //db.SaveChanges();

            Console.WriteLine("Press Key");
        }
    }
}