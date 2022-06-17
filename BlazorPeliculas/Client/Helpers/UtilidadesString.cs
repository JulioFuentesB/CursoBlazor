using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;

namespace BlazorPeliculas.Client.Helpers
{
    public class UtilidadesString
    {
        //exprecion implicita, no sabe donde empieza y donde terman
        public static string EnMayiscular(string valor) => valor.ToUpper();
    }

    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config )
        //{
        //    var cors = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cors);

        //    config.MapHttpAttributeRoutes();

        //}

        //public static void Register(HttpConfiguration config)
        //{
        //    config.MapHttpAttributeRoutes();

        //    var cors = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cors);
        //}

        //public static void Register(HttpConfiguration config)
        //{
        //    config.EnableCors();
        //    config.MapHttpAttributeRoutes();
        //}
    }

}
