using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Helpers
{
    public class UtilidadesString
    {
        //exprecion implicita, no sabe donde empieza y donde terman
        public static string EnMayiscular(string valor) => valor.ToUpper();
    }
}
