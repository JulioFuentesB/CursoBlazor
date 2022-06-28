using System;
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
        public bool EnCines { get; set; }
        public string Trailer { get; set; }
        [Required]
        public DateTime? FechaLanzamiento { get; set; }
        public string Poster { get; set; }
        public List<PeliculasGeneros> PeliculasGeneros { get; set; } = new List<PeliculasGeneros>();
        public List<PeliculasActores> PeliculasActores { get; set; }

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
