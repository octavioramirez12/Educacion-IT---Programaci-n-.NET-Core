using Api.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController
    {
        [HttpGet]
        [Route("BuscarRoles")]
        public async Task<List<Roles>> BuscarRoles()
        {
            var buscarRoles = new RolesService();
            return await buscarRoles.BuscarRolesAsync();
        }

        [HttpPost]
        [Route("GuardarRol")]
        public async Task<List<Roles>> GuardarRol(Roles model)
        {
            var service = new RolesService();
            return await service.GuardarRolAsync(model);
        }
        [HttpPost]
        [Route("EliminarRol")]
        public async Task<List<Roles>> EliminarRol(Roles model)
        {
            var service = new RolesService();
            return await service.EliminarRolAsync(model);
        }


    }
}
