using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPeliculas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServicioSingleton singleton { get; set; }
        [Inject] ServicioTransient transient { get; set; }
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;

        }
    }
}
