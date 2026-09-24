using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VapeUnity.Models;

namespace VapeUnity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Produtos2Controller : Controller
    {
        private readonly Contexto _context;
        private readonly string _caminhoServidor;

        public Produtos2Controller(IWebHostEnvironment ambiente, Contexto context)
        {
            _context = context;
            _caminhoServidor = ambiente.WebRootPath;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Lista()
        {
            return _context.Produtos != null ?
                View(await _context.Produtos.ToListAsync()) :
                Problem("Entity set 'Contexto.Produtos' is null.");
        }

        // GET: Produtos2
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.Produtos != null ?
                View(await _context.Produtos.ToListAsync()) :
                Problem("Entity set 'Contexto.Produtos' is null.");
        }

        // GET: Produtos2/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // GET: Produtos2/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Categoria,Disponibilidade,CaminhoImagens")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtos);
        }

        // GET: Produtos2/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return View(produtos);
        }

        // POST: Produtos2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Categoria,Disponibilidade,CaminhoImagens")] Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(produtos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtos);
        }

        // GET: Produtos2/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // POST: Produtos2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'Contexto.Produtos' is null.");
            }
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos != null)
            {
                _context.Produtos.Remove(produtos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Upload(IFormFile foto)
        {
            if (foto == null)
            {
                // Tratar o erro de arquivo nulo aqui, se necessário
                return BadRequest();
            }
            string caminhoParaSalvarImagem = _caminhoServidor + "\\img\\";
            string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;
            string caminhoCompleto = caminhoParaSalvarImagem + novoNomeParaImagem;
            GlobalVariables.ImagePath = caminhoCompleto;
            if (!Directory.Exists(caminhoParaSalvarImagem)) { Directory.CreateDirectory(caminhoParaSalvarImagem); }

            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
            {
                foto.CopyToAsync(stream);
            }

            // Adicione esta linha para atualizar o valor da div com o caminho da imagem

            string script = caminhoCompleto;
            return Ok();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
