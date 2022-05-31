using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        [Inject] protected IJSRuntime JS { get; set; }


        private int currentCount = 0;
        static int currentCountStatic = 0;


        [JSInvokable]
        public async Task IncrementCountAsync()
        {
            currentCount++;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
            currentCountStatic++;

            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");

        }


        protected async Task IncrementCountAsyncJavascript()
        {
            

            await JS.InvokeVoidAsync("pruebaPuntoNetInstancia",
                DotNetObjectReference.Create(this));
        }


        [JSInvokable]
        public static Task<int> ObtenerCurrebtCount()
        {
            return Task.FromResult(currentCountStatic);
        }

    }
}
