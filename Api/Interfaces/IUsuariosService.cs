using Data.Entities;

namespace Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<Usuarios>> BuscarUsuariosAsync();
        Task<List<Usuarios>> GuardarUsuarioAsync(Usuarios model);
        Task<List<Usuarios>> EliminarUsuarioAsync(Usuarios model);
    }
}
