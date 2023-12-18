using Microsoft.AspNetCore.Mvc;

namespace Educacion_IT___Programación_.NET.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Usuarios()
        {
            return View();
        }
        public IActionResult UsuariosAddPartial()
        {
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml");
        }

    }
}
