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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryID=1, CategoryName="Action/Adventure"},
                    new Category { CategoryID = 2, CategoryName = "Sci-fi" },
                    new Category { CategoryID = 3, CategoryName = "Comedy" },
                    new Category { CategoryID = 4, CategoryName = "Horror" },
                    new Category { CategoryID = 5, CategoryName = "Drama" },
                    new Category { CategoryID = 6, CategoryName = "Romance" },
                    new Category { CategoryID = 7, CategoryName = "Thriller" },
                    new Category { CategoryID = 8, CategoryName = "Fantasy" },
                    new Category { CategoryID = 9, CategoryName = "Western" },
                    new Category { CategoryID = 10, CategoryName = "Crime" },
                    new Category { CategoryID = 11, CategoryName = "Animation" },
                    new Category { CategoryID = 12, CategoryName = "War" },
                    new Category { CategoryID = 13, CategoryName = "Documentary" }
                );
            modelBuilder.Entity<AddMovie>().HasData(
                //Seed database
                new AddMovie
                {
                    MovieID = 1,
                    CategoryID = 1,
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
                    CategoryID = 2,
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
                    CategoryID = 12,
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
