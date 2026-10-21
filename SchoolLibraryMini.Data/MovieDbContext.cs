using SchoolLibraryMini.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibraryMini.Data
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Viewer> Viewers => Set<Viewer>();
        public DbSet<Rental> Rentals => Set<Rental>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(d => d.DirectorId);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);

                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(m => m.Genre)
                    .IsRequired();

                entity.HasOne(m => m.Director)
                    .WithMany(d => d.Movies)
                    .HasForeignKey(m => m.DirectorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Viewer>(entity =>
            {
                entity.HasKey(v => v.ViewerId);
                entity.Property(v => v.FullName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Rental>(entity => {
                entity.HasKey(r => new { r.MovieId, r.ViewerId });

                
                entity.HasOne(r => r.Movie)
                    .WithMany(m => m.Rentals)
                    .HasForeignKey(r => r.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);

                
                entity.HasOne(r => r.Viewer)
                    .WithMany(v => v.Rentals)
                    .HasForeignKey(r => r.ViewerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
