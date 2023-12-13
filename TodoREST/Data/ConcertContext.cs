using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoREST.Models;

namespace TodoREST.Data
{
    public class ConcertContext : DbContext
    {
        public ConcertContext(DbContextOptions<ConcertContext> options) : base(options)
        {
        }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<Show> Shows{ get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concert>().ToTable("Concert");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Show>().ToTable("Show");
            modelBuilder.Entity<Genre>().ToTable("Genre");

            modelBuilder.Entity<ConcertGenre>().HasKey(cg => new { cg.ConcertId, cg.GenreId });

            modelBuilder.Entity<ConcertGenre>()
                .HasOne(c => c.Concert)
                .WithMany(cg => cg.ConcertGenres)
                .HasForeignKey(c => c.ConcertId);

            modelBuilder.Entity<ConcertGenre>()
                .HasOne(g => g.Genre)
                .WithMany(cg => cg.ConcertGenres)
                .HasForeignKey(g => g.GenreId);
        }



    }

     
}
