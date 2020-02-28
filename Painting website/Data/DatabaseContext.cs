using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Painting_website.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Capstone.Models.Picture> Picture { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Tag>().HasData(
                  new Tag { Id = -1, Tags = "Hawks-Eagles" },
                  new Tag { Id = -2, Tags = "Owls" },
                  new Tag { Id = -3, Tags = "Small Songbirds" },
                  new Tag { Id = -4, Tags = "Ducks and Waterfowl" },
                  new Tag { Id = -5, Tags = "Larger Misc. Birds" },
                  new Tag { Id = -6, Tags = "Landscape" },
                  new Tag { Id = -7, Tags = "Non-Avian Wildlife" },
                  new Tag { Id = -8, Tags = "Shorebirds" }
            );


            modelBuilder.Entity<Location>().HasData(
              new Location { Id = -1, Place = "Northeast Photography" },
                  new Location { Id = -2, Place = "Florida Photography" },
                  new Location { Id = -3, Place = "Travel-Landscape Photography" }
            );
        }



        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Location> Place { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
