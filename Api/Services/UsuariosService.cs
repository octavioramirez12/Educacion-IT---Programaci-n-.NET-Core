using Api.Interfaces;
using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly UsuariosManager _manager;

        public UsuariosService()
        {
            _manager = new UsuariosManager();
        }

        public async Task<List<Usuarios>> BuscarUsuariosAsync()
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

        public async Task<List<Usuarios>> GuardarUsuarioAsync(Usuarios model)
        {
            var result = await _manager.Guardar(model, model.Id);
            return await _manager.BuscarListaAsync();
        }

        public async Task<List<Usuarios>> EliminarUsuarioAsync(Usuarios model)
        {
            model.Activo = false;
            var result = await _manager.Eliminar(model);
            return await _manager.BuscarListaAsync();
        }
    }
}
