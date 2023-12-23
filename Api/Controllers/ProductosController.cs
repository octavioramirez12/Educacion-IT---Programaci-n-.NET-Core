using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController
    {
        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<List<Productos>> BuscarProductos()
        {
            var buscarProductos = new ProductosService();
            return await buscarProductos.BuscarProductosAsync();
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<List<Productos>> GuardarProducto(Productos model)
        {
            var service = new ProductosService();
            return await service.GuardarProductoAsync(model);
        }
        [HttpPost]
        [Route("EliminarProducto")]
        public async Task<List<Productos>> EliminarProducto(Productos model)
        {
            var service = new ProductosService();
            return await service.EliminarProductoAsync(model);
        }


    }
}
