using System;

using Microsoft.EntityFrameworkCore;
using VideosMenuDAL.Entities;

namespace VideosMenuDAL.Context
{
    public class InMemoryContext : DbContext // DbContext is from EFCore = overall managing database. DbContext is superClass.
    {
        private static DbContextOptions<InMemoryContext> option = new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;

        //Options That we want in Memory
        public InMemoryContext() : base (option)
        {
            
        }

        /// <summary>
        /// This method overrides from DBContext. Fluent API, mapping JOIN Table "VideoGenre".
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            /// haskey(primary key); combining key of genre and video to get unique key.
            /// bound key.
            modelBuilder.Entity<VideoGenre>().HasKey(vg => new { vg.GenreId, vg.VideoId});

            modelBuilder.Entity<VideoGenre>().
                        HasOne(vg => vg.Genres)
                        .WithMany(g => g.Video)
                        .HasForeignKey(ca => ca.GenreId);

            modelBuilder.Entity<VideoGenre>()
                        .HasOne(v => v.Videos)
                        .WithMany(g => g.Genres)
                        .HasForeignKey(v => v.VideoId);

            base.OnModelCreating(modelBuilder);
        }

        // remember this is from entityFrameWork
        public DbSet<Video> Videos { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Rental> Rents { get; set; }
        
    }
}
