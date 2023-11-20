using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using System.Security.Claims;

namespace medcenter_backend.Controllers
{
    public class DependentesController : Controller
    {
        private readonly AppDbContext _context;

        public DependentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Dependentes.Include(d => d.Paciente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dependentes == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes
                .Include(d => d.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // GET: Dependentes/Create
        public IActionResult Create()
        {
            // Obter o ID do usuário logado
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pacienteId = _context.Pacientes
                .Where(p => p.Usuario.Email == userEmail)
                .Select(p => p.Id)
                .FirstOrDefault();

            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", pacienteId);
            return View();
        }

        // POST: Dependentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,PacienteId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                // Definir automaticamente o PacienteId com base no usuário logado
                var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var paciente = _context.Pacientes.FirstOrDefault(p => p.Usuario.Email == userEmail);

                if (paciente != null)
                {
                    dependente.PacienteId = paciente.Id;
                }

                _context.Add(dependente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pacientes");
            }

            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", dependente.PacienteId);
            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dependentes == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes
                .Include(d => d.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", dependente.PacienteId);
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,PacienteId")] Dependente dependente)
        {
            if (id != dependente.Id)
            {
                return NotFound();
            }

            // Exclua a vinculação do campo PacienteId
            ModelState.Remove("PacienteId");

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtenha o dependente original do banco de dados
                    var originalDependente = await _context.Dependentes.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                    // Atribua o PacienteId original ao modelo
                    dependente.PacienteId = originalDependente.PacienteId;

                    // Atualize as demais propriedades
                    _context.Update(dependente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteExists(dependente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Pacientes");
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", dependente.PacienteId);
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dependentes == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes
                .Include(d => d.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dependentes == null)
            {
                return Problem("Entity set 'AppDbContext.Dependentes'  is null.");
            }
            var dependente = await _context.Dependentes.FindAsync(id);
            if (dependente != null)
            {
                _context.Dependentes.Remove(dependente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pacientes");
        }

        private bool DependenteExists(int id)
        {
          return _context.Dependentes.Any(e => e.Id == id);
        }
    }
}
