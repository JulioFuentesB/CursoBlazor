function pruebaPuntoNetStatic() {
    DotNet.invokeMethodAsync("BlazorPeliculas.Client", "ObtenerCurrebtCount")
        .then(resultado => {
            console.log("conteo desde javascript:" + resultado)
    });
}


function pruebaPuntoNetInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCountAsync");

    //IncrementCountAsync
}