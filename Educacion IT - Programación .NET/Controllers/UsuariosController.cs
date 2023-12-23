using Data.Base;
using Data.Entities;
using Educacion_IT___Programación_.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Educacion_IT___Programación_.NET.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IHttpClientFactory _httpClient;
        public UsuariosController(IHttpClientFactory httpClient)
        {
            _httpClient= httpClient;
        }
        public IActionResult Usuarios()
        {
            return View();
        }
        public async Task<IActionResult> UsuariosAddPartial([FromBody]Usuarios usuario)
        {
            var usuarioViewModel = new UsuariosViewModel();
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.GetToApi("Roles/BuscarRoles");

            var resultadoRoles = roles as OkObjectResult;

            if (usuario != null)
            {
                usuarioViewModel = usuario;
            }

            if (resultadoRoles != null)
            {
                var listaRoles = JsonConvert.DeserializeObject<List<Roles>>(resultadoRoles.Value.ToString());
                var listaItemRoles = new List<SelectListItem>();

                foreach (var rol in listaRoles)
                {
                    listaItemRoles.Add(new SelectListItem { Text = rol.Nombre, Value = rol.Id.ToString()});
                }

                usuarioViewModel.Lista_Roles = listaItemRoles;
            }

            
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuarioViewModel);
        }

        public async Task<IActionResult> GuardarUsuario(Usuarios usuario)
        {
            var baseApi = new BaseApi(_httpClient);
            var usuarios = await baseApi.PostToApi("Usuarios/GuardarUsuario", usuario);

            return RedirectToAction("Usuarios", "Usuarios");
        }
        public async Task<IActionResult> EliminarUsuario([FromBody]Usuarios usuario)
        {
            var baseApi = new BaseApi(_httpClient);
            var usuarios = await baseApi.PostToApi("Usuarios/EliminarUsuario", usuario);

            return RedirectToAction("Usuarios", "Usuarios");
        }

    }
}
