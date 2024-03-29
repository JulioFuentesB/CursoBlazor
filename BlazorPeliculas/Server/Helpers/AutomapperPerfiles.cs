﻿using AutoMapper;
using BlazorPeliculas.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Server.Helpers
{
    public class AutomapperPerfiles: Profile
    {
        public AutomapperPerfiles()
        {
            CreateMap<Actores, Actores>()
                .ForMember(x => x.Foto, option => option.Ignore());

            CreateMap<Peliculas, Peliculas>()
                .ForMember(x => x.Poster, option => option.Ignore());
        }
    }
}
