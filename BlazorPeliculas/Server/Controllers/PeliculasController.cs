﻿using AutoMapper;
using BlazorPeliculas.Server.Helpers;
using BlazorPeliculas.Shared.DTOs;
using BlazorPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IAlmacenadorArchivos almacenadorDeArchivos;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context,
            IAlmacenadorArchivos almacenadorDeArchivos,
            IMapper mapper)
        {
            this.context = context;
            this.almacenadorDeArchivos = almacenadorDeArchivos;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            try
            {
                var limite = 6;

                var peliculasEnCartelera = await context.Peliculas
                    .Where(x => x.EnCines).Take(limite)
                    .OrderByDescending(x => x.FechaLanzamiento)
                    .ToListAsync();

                var fechaActual = DateTime.Today;

                var proximosEstrenos = await context.Peliculas
                    .Where(x => x.FechaLanzamiento > fechaActual)
                    .OrderBy(x => x.FechaLanzamiento).Take(limite)
                    .ToListAsync();

                var response = new HomePageDTO()
                {
                    PeliculasEnCartelera = peliculasEnCartelera,
                    ProximosEstrenos = proximosEstrenos
                };

                return response;
            }
            catch (Exception Ex)
            {

                throw;
            }

      

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaVisualizarDTO>> Get(int id)
        {
            try
            {

                Peliculas    pelicula = await context.Peliculas.Where(x => x.Id == id)
              .Include(x => x.PeliculasGeneros).ThenInclude(x => x.Genero)
              .Include(x => x.PeliculasActores).ThenInclude(x => x.Actor)
              .FirstOrDefaultAsync();

                if (pelicula == null) { return NotFound(); }

                // todo: sistema de votacion
                var promedioVotos = 4;
                var votoUsuario = 5;

                pelicula.PeliculasActores = pelicula.PeliculasActores.OrderBy(x => x.Orden).ToList();

                var model = new PeliculaVisualizarDTO();
                model.Pelicula = pelicula;
                model.Generos = pelicula.PeliculasGeneros.Select(x => x.Genero).ToList();
                model.Actores = pelicula.PeliculasActores.Select(x =>
                  new Actores
                  {
                      Nombre = x.Actor.Nombre,
                      Foto = x.Actor.Foto,
                      Personaje = x.Personaje,
                      Id = x.ActorId
                  }).ToList();

                model.PromedioVotos = promedioVotos;
                model.VotoUsuario = votoUsuario;
                return model;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

          
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<List<Peliculas>>> Get([FromQuery] ParametrosBusquedaPeliculas parametrosBusqueda)
        {
            var peliculasQueryable = context.Peliculas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Titulo))
            {
                peliculasQueryable = peliculasQueryable
                    .Where(x => x.Titulo.ToLower().Contains(parametrosBusqueda.Titulo.ToLower()));
            }

            if (parametrosBusqueda.EnCartelera)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCines);
            }

            if (parametrosBusqueda.Estrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(x => x.FechaLanzamiento >= hoy);
            }

            if (parametrosBusqueda.GeneroId != 0)
            {
                peliculasQueryable = peliculasQueryable
                    .Where(x => x.PeliculasGeneros.Select(y => y.GeneroId)
                    .Contains(parametrosBusqueda.GeneroId));
            }

            // TODO: Implementar votacion

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(peliculasQueryable, 
                parametrosBusqueda.CantidadRegistros);

            var peliculas = await peliculasQueryable.Paginar(parametrosBusqueda.Paginacion).ToListAsync();

            return peliculas;
        }

        public class ParametrosBusquedaPeliculas
        {
            public int Pagina { get; set; } = 1;
            public int CantidadRegistros { get; set; } = 10;
            public Paginacion Paginacion
            {
                get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
            }
            public string Titulo { get; set; }
            public int GeneroId { get; set; }
            public bool EnCartelera { get; set; }
            public bool Estrenos { get; set; }
            public bool MasVotadas { get; set; }
        }

        [HttpGet("actualizar/{id}")]
        public async Task<ActionResult<PeliculaActualizacionDTO>> PutGet(int id)
        {
            var peliculaActionResult = await Get(id);
            if (peliculaActionResult.Result is NotFoundResult) { return NotFound(); }

            var peliculaVisualizarDTO = peliculaActionResult.Value;
            var generosSeleccionadosIds = peliculaVisualizarDTO.Generos.Select(x => x.Id).ToList();
            var generosNoSeleccionados = await context.Generos
                .Where(x => !generosSeleccionadosIds.Contains(x.Id))
                .ToListAsync();

            var model = new PeliculaActualizacionDTO();
            model.Pelicula = peliculaVisualizarDTO.Pelicula;
            model.GenerosNoSeleccionados = generosNoSeleccionados;
            model.GenerosSeleccionados = peliculaVisualizarDTO.Generos;
            model.Actores = peliculaVisualizarDTO.Actores;
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Peliculas pelicula)
        {
            if (!string.IsNullOrWhiteSpace(pelicula.Poster))
            {
                var fotoPersona = Convert.FromBase64String(pelicula.Poster);
                pelicula.Poster = await almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "peliculas");
            }

            if (pelicula.PeliculasActores != null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Peliculas pelicula)
        {
            var peliculaDB = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == pelicula.Id);

            if (peliculaDB == null) { return NotFound(); }

            peliculaDB = mapper.Map(pelicula, peliculaDB);

            if (!string.IsNullOrWhiteSpace(pelicula.Poster))
            {
                var posterImagen = Convert.FromBase64String(pelicula.Poster);
                peliculaDB.Poster = await almacenadorDeArchivos.EditarArchivo(posterImagen,
                    "jpg", "peliculas", peliculaDB.Poster);
            }

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from GenerosPeliculas WHERE PeliculaId = {pelicula.Id}; delete from PeliculasActores where PeliculaId = {pelicula.Id}");

            if (pelicula.PeliculasActores != null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            peliculaDB.PeliculasActores = pelicula.PeliculasActores;
            peliculaDB.PeliculasGeneros = pelicula.PeliculasGeneros;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Peliculas.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Peliculas { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
