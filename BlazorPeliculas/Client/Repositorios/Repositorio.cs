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
            return new List<Peliculas>() {
                  new Peliculas()
                  {
                      Titulo = "Spider-Man: Far From Home",
                      FechaLanzamiento = new DateTime(2019, 7, 2),
                      Poster = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                  },
                    new Peliculas()
                    {
                        Titulo = "Moana",
                        FechaLanzamiento = new DateTime(2016, 11, 23),
                        Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"
                    },
                    new Peliculas()
                    {
                        Titulo = "Inception",
                        FechaLanzamiento = new DateTime(2010, 7, 16),
                        Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                    }
                };
        }

    }
}
