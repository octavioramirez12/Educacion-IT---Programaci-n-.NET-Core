using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController
    {
        [HttpGet]
        [Route("BuscarUsuarios")]
        public async Task<List<Usuarios>> BuscarUsuarios()
        {
            var buscarUsuarios = new UsuariosService();
            return await buscarUsuarios.BuscarUsuariosAsync();
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<List<Usuarios>> GuardarUsuario(Usuarios model)
        {
            var service = new UsuariosService();
            return await service.GuardarUsuarioAsync(model);
        }
    }
}
