using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculas.Shared.Entidades
{
    public class PeliculasGeneros
    {
        public int PeliculasId { get; set; }
        public int GeneroId { get; set; }

        public Generos Genero { get; set; }
        public Peliculas Pelicula { get; set; }

    }
}
