using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculas.Shared.DTOs
{
    public class PeliculaActualizacionDTO
    {
        public Peliculas Pelicula { get; set; }
        public List<Actores> Actores { get; set; }
        public List<Generos> GenerosSeleccionados { get; set; }
        public List<Generos> GenerosNoSeleccionados { get; set; }
    }
}
