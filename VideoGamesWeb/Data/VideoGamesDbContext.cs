using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using VideoGamesWeb.Data.Entities;

namespace VideoGamesWeb.Data
{
    public class VideoGamesDbContext : DbContext
    {

        public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().ToTable("VideoGame");
        }
        public DbSet<VideoGame> VideoGames { get; set; }


    }
}
