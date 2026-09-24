using Microsoft.AspNetCore.Mvc;

namespace VapeUnity.Controllers
{
    public class SobreNosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
