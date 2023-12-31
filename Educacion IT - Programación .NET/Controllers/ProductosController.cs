using Data.Base;
using Data.Entities;
using Educacion_IT___Programación_.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Educacion_IT___Programación_.NET.Controllers
{
    public class ProductosController : Controller
    {

        private readonly IHttpClientFactory _httpClient;
        public ProductosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Productos()
        {
            return View();
        }
        public async Task<IActionResult> ProductosAddPartial([FromBody] Productos producto)
        {
            var productoViewModel = new ProductosViewModel();

            if (producto != null)
            {
                productoViewModel = producto;
            }

            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", productoViewModel);
        }

        public async Task<IActionResult> GuardarProducto(Productos producto)
        {
            var baseApi = new BaseApi(_httpClient);
            if (producto.Imagen_Archivo != null && producto.Imagen_Archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    producto.Imagen_Archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    producto.Imagen = Convert.ToBase64String(imagenBytes);
                }
            }
            producto.Imagen_Archivo = null;
            var productos = await baseApi.PostToApi("Productos/GuardarProducto", producto);

            return RedirectToAction("Productos", "Productos");
        }
        public async Task<IActionResult> EliminarProducto([FromBody] Productos producto)
        {
            var baseApi = new BaseApi(_httpClient);
            var productos = await baseApi.PostToApi("Productos/EliminarProducto", producto);

            return RedirectToAction("Productos", "Productos");
        }

    }
}
