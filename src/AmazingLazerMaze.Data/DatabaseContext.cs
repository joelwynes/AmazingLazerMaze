using JoelWynes.AmazingLazerMaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace JoelWynes.AmazingLazerMaze.Data
{
    public class DatabaseContext : DbContext
    {

        public DbSet<MazeBoard> Mazes { get; set; }
        public DbSet<MazeRoom> MazeRooms { get; set; }
        public DbSet<Mirror> Mirrors { get; set; }
        public DbSet<LazerGun> LazerGuns { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public static DatabaseContext GetInMemoryDatabaseContextForUnitTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableDetailedErrors().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
              .Options;
            return new DatabaseContext(options);
        }
    }
}
