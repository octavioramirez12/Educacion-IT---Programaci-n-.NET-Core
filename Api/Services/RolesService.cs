using Api.Interfaces;
using Common.Helpers;
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
                GenerateLogHelper.LogError(ex, "RolesService", "BuscarRolesAsync");
                throw ex;
            }
        }

        public async Task<List<Roles>> GuardarRolAsync(Roles model)
        {
            try
            {
                var result = await _manager.Guardar(model, model.Id);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RolesService", "GuardarRolAsync");
                throw ex;
            }
        }

        public async Task<List<Roles>> EliminarRolAsync(Roles model)
        {
            try
            {
                model.Activo = false;
                var result = await _manager.Eliminar(model);
                return await _manager.BuscarListaAsync();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RolesService", "EliminarRolAsync");
                throw ex;
            }
        }
    }
}
