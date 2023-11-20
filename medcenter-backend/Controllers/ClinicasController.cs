using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;

namespace medcenter_backend.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly AppDbContext _context;

        public ClinicasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clinicas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Clinicas.Include(c => c.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Clinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clinicas == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinicas
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);

            return View(clinica);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf");
            return View();
        }

        // POST: Clinicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,Endereço,HoraInicioFuncionamento,HoraFimFuncionamento,UsuarioId")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", clinica.UsuarioId);
            return View(clinica);
        }

        // GET: Clinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clinicas == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinicas.FindAsync(id);

            // Adicione uma verificação para permitir apenas que a clínica correspondente edite as informações
            if (clinica != null && clinica.UsuarioId == id)
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", clinica.UsuarioId);
                return View(clinica);
            }

            return NotFound();
        }

        // POST: Clinicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Endereço,HoraInicioFuncionamento,HoraFimFuncionamento,UsuarioId")] Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicaExists(clinica.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", clinica.UsuarioId);
            return View(clinica);
        }

        // GET: Clinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clinicas == null)
            {
                return NotFound();
            }

            var clinica = await _context.Clinicas
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Id == id);

            return View(clinica);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clinicas == null)
            {
                return Problem("Clínica não encontrada para exclusão.");
            }

            var clinica = await _context.Clinicas.FindAsync(id);

            if (clinica == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.Clinicas.Remove(clinica);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ClinicaExists(int id)
        {
            return _context.Clinicas.Any(e => e.Id == id);
        }
    }
}
