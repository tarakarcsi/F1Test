using Dapper;
using F1Test.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace F1Test
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "F1TestDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
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

            //var team1 = new Team()
            //{
            //    Id = System.Guid.NewGuid(),
            //    Titles = 2,
            //    Name = "McLaren Mercedes",
            //    FoundationYear = 1934,
            //    HasPayed = true
            //};

            //var team2 = new Team()
            //{
            //    Id = System.Guid.NewGuid(),
            //    Titles = 12,
            //    Name = "Ferrari",
            //    FoundationYear = 1928,
            //    HasPayed = true
            //};

            //var team3 = new Team()
            //{
            //    Id = System.Guid.NewGuid(),
            //    Titles = 2,
            //    Name = "Mercedes-Benz",
            //    FoundationYear = 1932,
            //    HasPayed = true
            //};

            //using (var context = new DatabaseContext())
            //{
            //    context.AddRange(team1, team2, team3);
            //    context.SaveChanges();
            //}
        }

        public static List<Team> LoadTeams()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var teams = cnn.Query<Team>("select * from Team", new DynamicParameters());
                return teams.ToList();
            }
        }

        public static void SaveTeam(Team team)
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Team (Id, Name, FoundationYear, Titles, HasPayed) values (@Id, @Name, @FoundationYear, @Titles, @HasPayed)", team);
            }
        }

        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; 
        }
    }
}
