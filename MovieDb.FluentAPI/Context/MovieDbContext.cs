using Microsoft.EntityFrameworkCore;
using MovieDb.FluentAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb.FluentAPI.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieGenre> MoviewGenres { get; set; }
        public DbSet<MovieDirection> MovieDirections { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=MovieDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCast>()
                .HasOne<Actor>(a => a.Actor)
                .WithMany(m => m.MovieCasts);

            modelBuilder.Entity<MovieCast>()
                .HasOne<Movie>(m => m.Movie)
                .WithMany(mc => mc.MovieCasts);

            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.ActorId});

            modelBuilder.Entity<MovieDirection>()
                .HasOne<Movie>(m => m.Movie)
                .WithMany(md => md.MovieDirections);

            modelBuilder.Entity<MovieDirection>()
                .HasOne<Director>(d => d.Director)
                .WithMany(md => md.MovieDirections);

            modelBuilder.Entity<MovieDirection>().HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<Rating>()
                .HasOne<Reviewer>(r => r.Reviewer)
                .WithMany(r => r.Ratings);

            modelBuilder.Entity<Rating>()
                .HasOne<Movie>(m => m.Movie)
                .WithMany(r => r.Ratings);

            modelBuilder.Entity<Rating>().HasKey(r => new { r.MovieId, r.ReviewId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne<Movie>(m => m.Movie)
                .WithMany(mg => mg.MovieGenres);

            modelBuilder.Entity<MovieGenre>()
                .HasOne<Genre>(g => g.Genre)
                .WithMany(mg => mg.MovieGenres);

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
        }
    }
}
