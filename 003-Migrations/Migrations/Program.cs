using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new MusicDbContext();
            // Create(db);
            // ShowData(db);
            // ShowDataInclude(db);
            UpdateData(db);
            System.Console.WriteLine("Presiona");
            Console.ReadLine();
        }

        private static void UpdateData(MusicDbContext db){
            var result = db.Bands
                            .Include(b => b.Albums)
                           .SingleAsync(b => b.Id ==2 )
                           .Result;
            result.Name = "Nirvana";

            result.Albums.Add(new Album(){ Title = "Nirbana Album", Year = 2004, Style = MusicStyle.Blues });

            db.SaveChanges();
        }
        
        private static void ShowDataInclude( MusicDbContext db){
         var results = db.Bands
                            .Include(b=>b.Albums)
                            .ToListAsync()
                            .Result;
            foreach (var item in results)
            {
                System.Console.WriteLine(item.Name);
                foreach (var album in item.Albums)
                {
                    System.Console.WriteLine(album.Title);
                }
            }
        }

        private static void ShowDataSimple( MusicDbContext db){
         var results = db.Bands.ToListAsync().Result;
            foreach (var item in results)
            {
                System.Console.WriteLine(item.Name);
            }
        }

        private static void Create(MusicDbContext db){
            var newBand = new Band();
            newBand.Name = "Bettles";

            var newAlbum = new Album { Title = "Bettles", Year = 2024, Style = MusicStyle.Blues };
            newBand.Albums= new List<Album>();
            newBand.Albums.Add(newAlbum);
            db.Bands.Add(newBand);
            db.SaveChanges();
        }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public MusicStyle Style { get; set; }
        public int BandId { get; set; }
    }

    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set;}
    }

    public enum MusicStyle
    {
        Grunge,
        Soul,
        Blues,
        Hiphop,
        Metal
    }

    public class MusicDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ARMANI\SQLEXPRESS; Initial Catalog=Music;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

    }
}
