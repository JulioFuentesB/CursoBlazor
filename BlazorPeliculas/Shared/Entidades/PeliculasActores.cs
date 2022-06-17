using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.Entidades
{
   public class PeliculasActores
    {
        public int PersonasId { get; set; }
        public int PeliculasId { get; set; }

        public Personas Persona { get; set; }
        public Peliculas Pelicula { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }

    }
}
