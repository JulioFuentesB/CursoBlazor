using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPeliculas.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Peliculas> PeliculasEnCartelera { get; set; }
        public List<Peliculas> ProximosEstrenos { get; set; }
    }
}
