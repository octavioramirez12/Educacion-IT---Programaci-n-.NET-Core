using Data.Base;
using Data.Entities;
using Educacion_IT___Programación_.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult UsuariosAddPartial([FromBody]Usuarios usuario)
        {
            var usuarioViewModel = new UsuariosViewModel();
            if(usuario != null)
            {
                usuarioViewModel = usuario;
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
