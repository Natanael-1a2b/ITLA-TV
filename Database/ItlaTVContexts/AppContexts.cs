using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItlaTVContexts
{
    public class AppContexts : DbContext
    {
        public AppContexts(DbContextOptions<AppContexts> options) : base(options) { }

        
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productoras");

            //primary key
            modelBuilder.Entity<Serie>().HasKey(serie => serie.IdSerie );
            modelBuilder.Entity<Genero>().HasKey(genero => genero.IdGenero);
            modelBuilder.Entity<Productora>().HasKey(productora => productora.IdProductora);

            // Relación Productora-Serie
            modelBuilder.Entity<Productora>()
        .HasMany<Serie>(productora => productora.Serie)
        .WithOne(serie => serie.Productora)
        .HasForeignKey(serie => serie.IdProductora)
        .OnDelete(DeleteBehavior.Cascade);

            // Relación Serie-Genero1
            modelBuilder.Entity<Serie>()
                .HasOne<Genero>(serie => serie.Genero1)
                .WithMany(genero => genero.SeriesComoGenero1)
                .HasForeignKey(serie => serie.IdGenero1)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Serie-Genero2
            modelBuilder.Entity<Serie>()
                .HasOne<Genero>(serie => serie.Genero2)
                .WithMany(genero => genero.SeriesComoGenero2)
                .HasForeignKey(serie => serie.IdGenero2)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
