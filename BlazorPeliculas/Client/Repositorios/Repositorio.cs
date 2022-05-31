using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public List<Peliculas> ObtenrPeliculas()
        {
            return new List<Peliculas>()
                {
                    new Peliculas(){Titulo = "Spider-Man: Far From Home", FechaLanzamiento  = new DateTime(2019, 7, 2)},
                    new Peliculas(){Titulo = "Moana", FechaLanzamiento  = new DateTime(2016, 11, 23)},
                    new Peliculas(){Titulo = "Inception", FechaLanzamiento  = new DateTime(2010, 7, 16)}
                };
        }
    }
}
