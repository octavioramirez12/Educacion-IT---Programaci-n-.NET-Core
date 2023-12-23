using Data.Entities;

namespace Api.Interfaces
{
    public interface IProductosService
    {
        Task<List<Productos>> BuscarProductosAsync();
        Task<List<Productos>> GuardarProductoAsync(Productos model);
        Task<List<Productos>> EliminarProductoAsync(Productos model);
    }
}
