using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VapeUnity.Models;
using System.Text.RegularExpressions;

namespace VapeUnity.Controllers
{
    [AllowAnonymous]
    public class ClientesController : Controller
    {
        private readonly Contexto _context;

        public ClientesController(Contexto context)
        {
            _context = context;
        }
        //ATUALIZAR CLIENTES

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return _context.Clientes != null ?
                        View(await _context.Clientes.ToListAsync()) :
                        Problem("Entity set 'Contexto.Clientes'  is null.");
        }

        public string GetUserNameByEmail(string email)
        {
            var userName = _context.Users
                .Where(u => u.Email == email)
                .Select(u => u.UserName)
                .FirstOrDefault();

            return userName;
        }

        public List<Clientes> GetClientesByEmail(string email)
        {
            var clientes = _context.Clientes
                .Where(c => c.Email == email)
                .ToList();

            return clientes;
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apelido,Morada,Nif,Telefone,Email")] Clientes clientes)
        {
            // Verifica se já existe um cliente com o email fornecido
            var existingCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == clientes.Email);
            if (existingCliente != null)
            {
                ModelState.AddModelError("Email", "Já existe um cliente com este email.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(clientes);
        }

        public IActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("Id,Nome,Apelido,Morada,Nif,Telefone,Email")] Clientes clientes)
        {
            // Verifica se já existe um cliente com o email fornecido
            var existingCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == clientes.Email);
            if (existingCliente != null)
            {
                ModelState.AddModelError("Email", "Já existe um cliente com este email.");
            }

            var existingEmail = GetUserNameByEmail(clientes.Email);
            if (existingEmail != GlobalVariables.Email)
            {
                ModelState.AddModelError("Email", "O email não não é válido.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction("AreaCliente", "Clientes");
            }

            return View(clientes);
        }


        [HttpGet]
        public JsonResult AtualizarCampoTexto()
        {
            string novoEmail = GlobalVariables.Email;
            string novoUserId = "colocar_id_aqui"; // Obtenha o valor de UserId de acordo com a lógica do seu aplicativo

            return Json(new { sucesso = true, email = novoEmail, userId = novoUserId });
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Apelido,Morada,Nif,Telefone,Email")] Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.Id))
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
            return View(clientes);
        }


        public async Task<IActionResult> EditClientesByEmail()
        {
            string email = GlobalVariables.Email;
            List<Clientes> clientes = GetClientesByEmail(email);

            ViewData["Clientes"] = clientes;

            Clientes cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == GlobalVariables.Email);

            if (cliente == null)
            {
                // Cliente não encontrado
                return NotFound();
            }

            return View(cliente);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClientesByEmail([Bind("Nome,Apelido,Morada,Nif,Telefone")] Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verifique se o campo "Nif" tem 9 dígitos
                    if (!Regex.IsMatch(cliente.Nif, @"^\d+$") && cliente.Nif.Length != 9)
                    {
                        ModelState.AddModelError("Nif", "O campo Nif deve ter exatamente 9 dígitos e ser composto apenas por números.");
                        return View(cliente);
                    }

                    // Verifique se o campo "Telefone" tem 9 dígitos
                    if (!Regex.IsMatch(cliente.Telefone, @"^\d+$") && cliente.Telefone.Length != 9)
                    {
                        ModelState.AddModelError("Telefone", "O campo Telefone deve ter exatamente 9 dígitos e ser composto apenas por números.");
                        return View(cliente);
                    }

                    // Buscar o cliente pelo email
                    Clientes clienteExistente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == GlobalVariables.Email);

                    if (clienteExistente == null)
                    {
                        // Cliente não encontrado
                        ModelState.AddModelError("", "Cliente não encontrado");
                        return View(cliente);
                    }

                    // Atualize os dados do cliente existente com os dados do cliente recebido no formulário
                    clienteExistente.Nome = cliente.Nome;
                    clienteExistente.Apelido = cliente.Apelido;
                    clienteExistente.Morada = cliente.Morada;
                    clienteExistente.Nif = cliente.Nif;
                    clienteExistente.Telefone = cliente.Telefone;

                    // Salve as alterações na base de dados
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Os dados do cliente foram atualizados com sucesso!";

                    // Redirecione para uma página de sucesso ou faça qualquer outra ação necessária
                    return RedirectToAction("EditClientesByEmail");
                }
                catch (Exception)
                {
                    // Ocorreu um erro ao atualizar os dados do cliente
                    ModelState.AddModelError("", "Ocorreu um erro ao atualizar os dados do cliente");
                    TempData["MensagemFalha"] = "Falha ao atualizar os dados do cliente. Verifique os dados e tente novamente.";
                    return View(cliente);
                }
            }

            // O modelo não é válido, retorne a view com os erros de validação
            return View(cliente);
        }


        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'Contexto.Clientes'  is null.");
            }
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> AreaCliente()
        {
            // Verificar se existe um cliente com o email do utilizador
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == User.Identity.Name);

            if (cliente != null)
            {
                ViewBag.HasExistingCliente = true;
                return View(cliente);
            }
            else
            {
                ViewBag.HasExistingCliente = false;
                return View();
            }
        }


        private void AtualizarCliente(string email, Clientes clienteAtualizado)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == email);

            if (cliente != null)
            {
                cliente.Nome = clienteAtualizado.Nome;
                cliente.Apelido = clienteAtualizado.Apelido;
                cliente.Nif = clienteAtualizado.Nif;
                cliente.Morada = clienteAtualizado.Morada;
                cliente.Telefone = clienteAtualizado.Telefone;

                _context.SaveChanges();
            }
        }

    }
}
