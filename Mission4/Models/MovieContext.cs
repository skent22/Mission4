using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<AddMovie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddMovie>().HasData(
                //Seed database
                new AddMovie
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Stetson Kent",
                    Notes = "best batman ever"
                },
                new AddMovie
                {
                    MovieID = 2,
                    Category = "Sci-fi",
                    Title = "Star Wars: Episode VI-Return of the Jedi",
                    Year = 1983,
                    Director = "Richard Marquand",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new AddMovie
                {
                    MovieID = 3,
                    Category = "War/Drama",
                    Title = "In This Corner of the World",
                    Year = 2016,
                    Director = "Sunao Katabuchi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
