using Api.Interfaces;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class RolesService : IRolesService
    {
        private readonly RolesManager _manager;

        public RolesService()
        {
            _manager = new RolesManager();
        }

        public async Task<List<Roles>> BuscarRolesAsync()
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

        public async Task<List<Roles>> GuardarRolAsync(Roles model)
        {
            var result = await _manager.Guardar(model, model.Id);
            return await _manager.BuscarListaAsync();
        }

        public async Task<List<Roles>> EliminarRolAsync(Roles model)
        {
            model.Activo = false;
            var result = await _manager.Eliminar(model);
            return await _manager.BuscarListaAsync();
        }
    }
}
