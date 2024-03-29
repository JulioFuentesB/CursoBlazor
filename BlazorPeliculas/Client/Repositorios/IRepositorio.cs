﻿using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        List<Peliculas> ObtenrPeliculas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);

        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
    }
}
