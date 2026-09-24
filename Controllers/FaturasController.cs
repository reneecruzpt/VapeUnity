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
    public class FaturasController : Controller
    {
        private readonly Contexto _context;

        public FaturasController(Contexto context)
        {
            _context = context;
        }

        // GET: Faturas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Faturas.Include(f => f.Cli);
            return View(await contexto.ToListAsync());
        }

        // GET: Faturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Faturas == null)
            {
                return NotFound();
            }

            var faturas = await _context.Faturas
                .Include(f => f.Cli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faturas == null)
            {
                return NotFound();
            }

            return View(faturas);
        }

        // GET: Faturas/Create
        public IActionResult Create()
        {
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Faturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Cliente,Total")] Faturas faturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id", "Id", faturas.Id_Cliente);
            return View(faturas);
        }

        // GET: Faturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Faturas == null)
            {
                return NotFound();
            }

            var faturas = await _context.Faturas.FindAsync(id);
            if (faturas == null)
            {
                return NotFound();
            }
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id", "Id", faturas.Id_Cliente);
            return View(faturas);
        }

        // POST: Faturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Cliente,Total")] Faturas faturas)
        {
            if (id != faturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturasExists(faturas.Id))
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
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id", "Id", faturas.Id_Cliente);
            return View(faturas);
        }

        // GET: Faturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Faturas == null)
            {
                return NotFound();
            }

            var faturas = await _context.Faturas
                .Include(f => f.Cli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faturas == null)
            {
                return NotFound();
            }

            return View(faturas);
        }

        // POST: Faturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Faturas == null)
            {
                return Problem("Entity set 'Contexto.Faturas'  is null.");
            }
            var faturas = await _context.Faturas.FindAsync(id);
            if (faturas != null)
            {
                _context.Faturas.Remove(faturas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturasExists(int id)
        {
          return (_context.Faturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
