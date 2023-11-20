using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace medcenter_backend.Migrations
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var consultas = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dependente)
                .Include(c => c.Clinica)
                .Include(c => c.Medico)
                .ToListAsync();

            return View(consultas);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            var pacientes = _context.Pacientes.ToList();
            var dependents = _context.Dependentes.ToList();
            var medicos = _context.Medicos.ToList();
            var clinicas = _context.Clinicas.ToList();

            ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nome");
            ViewBag.Dependentes = new SelectList(dependents, "Id", "Nome");
            ViewBag.Medicos = new SelectList(medicos, "Id", "Nome");
            ViewBag.Clinicas = new SelectList(clinicas, "Id", "Nome");

            return View();
        }

        // POST: Consultas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,DependenteId,MedicoId,ClinicaId,DataConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                // Certifique-se de que o DependenteId seja nulo se não for selecionado
                if (consulta.DependenteId == 0)
                {
                    consulta.DependenteId = null;
                }

                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", consulta.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", consulta.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", consulta.ClinicaId);

            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dependente)
                .Include(c => c.Clinica)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", consulta.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", consulta.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", consulta.ClinicaId);

            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,DependenteId,MedicoId,ClinicaId,DataConsulta")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Certifique-se de que o DependenteId seja nulo se não for selecionado
                    if (consulta.DependenteId == 0)
                    {
                        consulta.DependenteId = null;
                    }

                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", consulta.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", consulta.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", consulta.ClinicaId);

            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dependente)
                .Include(c => c.Clinica)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consultas == null)
            {
                return Problem("Entity set 'AppDbContext.Consultas'  is null.");
            }
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
          return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
