using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace VapeUnity.Controllers
{
    public class AdministracaoController : Controller
    {
        public IActionResult GVariables()
        {
            ViewBag.IdUser = GlobalVariables.IdUser;
            ViewBag.Email = GlobalVariables.Email;
            ViewBag.IdCliente = GlobalVariables.IdCliente;

            return View("~/Views/Administracao/GVariables.cshtml");
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return View("~/Views/Acesso/AcessoNegado.cshtml");
        }

        [HttpGet]
        public IActionResult VerificarAutenticacao()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { autenticado = true });
            }
            else
            {
                return Ok(new { autenticado = false });
            }
        }

    }
}
