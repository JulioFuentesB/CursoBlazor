﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculas.Shared.Entidades
{
    public class GenerosPeliculas
    {
        public int PeliculasId { get; set; }
        public int GenerosId { get; set; }

        public Generos Genero { get; set; }
        public Peliculas Pelicula { get; set; }

    }
}
