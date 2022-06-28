using BlazorPeliculas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculasGeneros>().HasKey(x => new { x.GeneroId, x.PeliculasId });
            modelBuilder.Entity<PeliculasActores>().HasKey(x => new { x.PeliculasId, x.ActorId });

            //var personas = new List<Persona>();
            //for (int i = 5; i < 100; i++)
            //{
            //    personas.Add(new Persona()
            //    {
            //        Id = i,
            //        Nombre = $"Persona {i}",
            //        FechaNacimiento = DateTime.Today
            //    });
            //}

            //modelBuilder.Entity<Persona>().HasData(personas);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Actores> Actores { get; set; }
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
    }
}
