using F1Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Test
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team", "f1test");
            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(entity => entity.Id);
                e.Property(entity => entity.Name);
                e.Property(entity => entity.Titles);
                e.Property(entity => entity.FoundationYear);
                e.Property(entity => entity.HasPayed);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
