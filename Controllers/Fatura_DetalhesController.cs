using System;
using System.Collections.Generic;
using System.Data;
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
    public class Fatura_DetalhesController : Controller
    {
        private readonly Contexto _context;

        public Fatura_DetalhesController(Contexto context)
        {
            _context = context;
        }

        // GET: Fatura_Detalhes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.FaturaDetalhes.Include(f => f.Fat).Include(f => f.Prod);
            return View(await contexto.ToListAsync());
        }

        // GET: Fatura_Detalhes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FaturaDetalhes == null)
            {
                return NotFound();
            }

            var fatura_Detalhes = await _context.FaturaDetalhes
                .Include(f => f.Fat)
                .Include(f => f.Prod)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatura_Detalhes == null)
            {
                return NotFound();
            }

            return View(fatura_Detalhes);
        }

        // GET: Fatura_Detalhes/Create
        public IActionResult Create()
        {
            ViewData["Id_Fatura"] = new SelectList(_context.Faturas, "Id", "Id");
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Id");
            return View();
        }

        // POST: Fatura_Detalhes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Fatura,Id_Produto,Preco,Quantidade,Total")] Fatura_Detalhes fatura_Detalhes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatura_Detalhes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Fatura"] = new SelectList(_context.Faturas, "Id", "Id", fatura_Detalhes.Id_Fatura);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Id", fatura_Detalhes.Id_Produto);
            return View(fatura_Detalhes);
        }

        // GET: Fatura_Detalhes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FaturaDetalhes == null)
            {
                return NotFound();
            }

            var fatura_Detalhes = await _context.FaturaDetalhes.FindAsync(id);
            if (fatura_Detalhes == null)
            {
                return NotFound();
            }
            ViewData["Id_Fatura"] = new SelectList(_context.Faturas, "Id", "Id", fatura_Detalhes.Id_Fatura);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Id", fatura_Detalhes.Id_Produto);
            return View(fatura_Detalhes);
        }

        // POST: Fatura_Detalhes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Fatura,Id_Produto,Preco,Quantidade,Total")] Fatura_Detalhes fatura_Detalhes)
        {
            if (id != fatura_Detalhes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatura_Detalhes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Fatura_DetalhesExists(fatura_Detalhes.Id))
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
            ViewData["Id_Fatura"] = new SelectList(_context.Faturas, "Id", "Id", fatura_Detalhes.Id_Fatura);
            ViewData["Id_Produto"] = new SelectList(_context.Produtos, "Id", "Id", fatura_Detalhes.Id_Produto);
            return View(fatura_Detalhes);
        }

        // GET: Fatura_Detalhes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FaturaDetalhes == null)
            {
                return NotFound();
            }

            var fatura_Detalhes = await _context.FaturaDetalhes
                .Include(f => f.Fat)
                .Include(f => f.Prod)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatura_Detalhes == null)
            {
                return NotFound();
            }

            return View(fatura_Detalhes);
        }

        // POST: Fatura_Detalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FaturaDetalhes == null)
            {
                return Problem("Entity set 'Contexto.Fatrura_detalhes'  is null.");
            }
            var fatura_Detalhes = await _context.FaturaDetalhes.FindAsync(id);
            if (fatura_Detalhes != null)
            {
                _context.FaturaDetalhes.Remove(fatura_Detalhes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Fatura_DetalhesExists(int id)
        {
          return (_context.FaturaDetalhes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
