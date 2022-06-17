﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.Entidades
{
    public class Peliculas
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public bool EnCartelera { get; set; }
        public string Trailer { get; set; }
        [Required]
        public DateTime? FechaLanzamiento { get; set; }
        public string Poster { get; set; }
        public List<GenerosPeliculas> GenerosPelicula { get; set; } = new List<GenerosPeliculas>();
        public List<PeliculasActores> PeliculasActor { get; set; }

        public string TituloCortado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Titulo))
                {
                    return null;
                }

                if (Titulo.Length > 60)
                {
                    return Titulo.Substring(0, 60) + "...";
                }
                else
                {
                    return Titulo;
                }
            }
        }
    }
}
