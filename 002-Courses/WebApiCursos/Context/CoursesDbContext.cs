using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Context
{
    public class CoursesDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public CoursesDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
