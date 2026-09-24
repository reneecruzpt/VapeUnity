using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VapeUnity.Controllers
{
    [AllowAnonymous]
    public class ImagensController : Controller
    {
        private string caminhoServidor;

        public ImagensController(IWebHostEnvironment sistema) { caminhoServidor = sistema.WebRootPath; }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile foto)
        {
            if (foto == null)
            {
                // Tratar o erro de arquivo nulo aqui, se necessário
                return BadRequest();
            }

            string caminhoParaSalvarImagem = Path.Combine(caminhoServidor, "img");
            string novoNomeParaImagem = $"{Guid.NewGuid()}_{foto.FileName}";
            string final = Path.Combine(caminhoParaSalvarImagem, novoNomeParaImagem);
            if (!Directory.Exists(caminhoParaSalvarImagem)) { Directory.CreateDirectory(caminhoParaSalvarImagem); }

            using (var stream = new FileStream(final, FileMode.Create))
            {
                await foto.CopyToAsync(stream);
                final = final.Replace(caminhoServidor, "~");
                final = final.Replace(@"\", "/");
                GlobalVariables.ImagePath = final;
            }

            return RedirectToAction("Upload");
        }

    }
}
