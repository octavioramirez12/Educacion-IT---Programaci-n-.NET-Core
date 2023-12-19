using Data.Base;
using Data.Entities;
using Educacion_IT___Programación_.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Educacion_IT___Programación_.NET.Controllers
{
    public class RolesController : Controller
    {

        private readonly IHttpClientFactory _httpClient;
        public RolesController(IHttpClientFactory httpClient)
        {
            _httpClient= httpClient;
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult RolesAddPartial([FromBody]Roles rol)
        {
            var rolViewModel = new RolesViewModel();
            if(rol != null)
            {
                rolViewModel = rol;
            }
            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", rolViewModel);
        }

        public async Task<IActionResult> GuardarRol(Roles rol)
        {
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.PostToApi("Roles/GuardarRol", rol);

            return RedirectToAction("Roles", "Roles");
        }
        public async Task<IActionResult> EliminarRol([FromBody]Roles rol)
        {
            var baseApi = new BaseApi(_httpClient);
            var roles = await baseApi.PostToApi("Roles/EliminarRol", rol);

            return RedirectToAction("Roles", "Roles");
        }

    }
}
