using Api.Interfaces;
using Common.Helpers;
using Data.Entities;
using Data.Manager;
using System.Linq.Expressions;

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
                GenerateLogHelper.LogError(ex, "ProductosService", "BuscarProductosAsync");
                throw ex;
            }
        }

        public async Task<List<Productos>> GuardarProductoAsync(Productos model)
        {
            try
            {
                var result = await _manager.Guardar(model, model.Id);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "ProductosService", "GuardarProductoAsync");
                throw ex;
            }
        }

        public async Task<List<Productos>> EliminarProductoAsync(Productos model)
        {
            try
            {
                model.Activo = false;
                var result = await _manager.Eliminar(model);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "ProductosService", "EliminarProductoAsync");
                throw ex;
            }
        }
    }
}
