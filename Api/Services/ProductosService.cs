using Api.Interfaces;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class ProductosService : IProductosService
    {
        private readonly ProductosManager _manager;

        public ProductosService()
        {
            _manager = new ProductosManager();
        }

        public async Task<List<Productos>> BuscarProductosAsync()
        {
            try
            {
                var result = await _manager.BuscarListaAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Productos>> GuardarProductoAsync(Productos model)
        {
            var result = await _manager.Guardar(model, model.Id);
            return await _manager.BuscarListaAsync();
        }

        public async Task<List<Productos>> EliminarProductoAsync(Productos model)
        {
            model.Activo = false;
            var result = await _manager.Eliminar(model);
            return await _manager.BuscarListaAsync();
        }
    }
}
