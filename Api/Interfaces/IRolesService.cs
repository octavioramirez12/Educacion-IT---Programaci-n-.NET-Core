using Data.Entities;

namespace Api.Interfaces
{
    public interface IRolesService
    {
        Task<List<Roles>> BuscarRolesAsync();
        Task<List<Roles>> GuardarRolAsync(Roles model);
        Task<List<Roles>> EliminarRolAsync(Roles model);
    }
}
