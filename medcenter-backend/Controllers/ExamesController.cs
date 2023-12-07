using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;

namespace medcenter_backend.Controllers
{
    [Authorize(Roles = "Medico, Admin, Clinica")]
    public class ExamesController : Controller
    {
        private readonly AppDbContext _context;

        public ExamesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Exames
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obter o paciente associado ao usuário conectado
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Usuario.Email == userEmail);

            if (paciente == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var exames = await _context.Exames
                .Include(e => e.Paciente)
                .Include(e => e.Dependente)
                .Include(e => e.Clinica)
                .Include(e => e.Medico)
                .ToListAsync();

            // Verificar a função do usuário
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            if (!roles.Contains("Admin") && !roles.Contains("Medico"))
            {
                // Se o usuário não for Admin nem Medico, filtrar apenas os exames do paciente
                exames = exames.Where(e => e.PacienteId == paciente.Id).ToList();
            }

            return View(exames);
        }


        // GET: Exames/Create
        public IActionResult Create()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obter o médico associado ao usuário conectado
            var medico = _context.Medicos.FirstOrDefault(m => m.Usuario.Email == userEmail);

            // Obter todos os pacientes e dependentes
            var pacientes = _context.Pacientes.ToList();
            var dependentes = _context.Dependentes.ToList();

            // Obter todas as clínicas e médicos
            var clinicas = _context.Clinicas.ToList();
            var medicos = _context.Medicos.ToList();

            // Criar um novo exame com o status "Agendado"
            var novoExame = new Exame
            {
                DataExame = DateTime.Now,
                Status = StatusExame.Agendado,
                MedicoId = 1
            };

            ViewBag.Pacientes = new SelectList(pacientes, nameof(Paciente.Id), nameof(Paciente.Nome));
            ViewBag.Dependentes = new SelectList(dependentes, nameof(Dependente.Id), nameof(Dependente.Nome));
            ViewBag.Medicos = new SelectList(medicos, nameof(Medico.Id), nameof(Medico.Nome));
            ViewBag.Clinicas = new SelectList(clinicas, nameof(Clinica.Id), nameof(Clinica.Nome));

            return View(novoExame);
        }

        
        // POST: Exames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,DependenteId,MedicoId,ClinicaId,DataExame,Status,TipoExame,Endereco")] Exame exame)
        {
            if (!IsValidExameDate(exame.DataExame))
            {
                ModelState.AddModelError("DataExame", "O exame só pode ser agendado de segunda a sexta entre 07h e 18h, e aos sábados de 08h às 12h.");
            }

            // Verificar se a data do exame está no futuro
            if (exame.DataExame < DateTime.Now)
            {
                ModelState.AddModelError("DataExame", "A data do exame deve ser no futuro.");
            }

            if (ModelState.IsValid)
            {
                // Certifique-se de que o DependenteId seja nulo se não for selecionado
                if (exame.DependenteId == 0)
                {
                    exame.DependenteId = null;
                }

                _context.Add(exame);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Recarregar a lista de pacientes e dependentes com base na escolha do usuário
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var medico = _context.Medicos.FirstOrDefault(m => m.Usuario.Email == userEmail);

            var pacientes = _context.Pacientes.ToList();
            var dependentes = exame.PacienteId != null ? _context.Dependentes.Where(d => d.PacienteId == exame.PacienteId).ToList() : new List<Dependente>();

            var clinicas = _context.Clinicas.ToList();
            var medicos = _context.Medicos.ToList();

            ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nome", exame.PacienteId);
            ViewBag.Dependentes = new SelectList(dependentes, "Id", "Nome", exame.DependenteId);
            ViewBag.Medicos = new SelectList(medicos, "Id", "Nome", exame.MedicoId);
            ViewBag.Clinicas = new SelectList(clinicas, "Id", "Nome", exame.ClinicaId);

            return View(exame);
        }

        // GET: Exames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames.FindAsync(id);

            if (exame == null)
            {
                return NotFound();
            }

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", exame.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", exame.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", exame.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", exame.ClinicaId);

            // Certifique-se de que TiposExame esteja populado
            ViewBag.TiposExame = Enum.GetValues(typeof(TipoExame))
                .Cast<TipoExame>()
                .Select(t => new SelectListItem
                {
                    Value = t.ToString(),
                    Text = t.ToString(),
                    Selected = t == exame.TipoExame
                });

            // Certifique-se de que Enderecos esteja populado
            ViewBag.Enderecos = Enum.GetValues(typeof(EnderecoExame))
                .Cast<EnderecoExame>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString(),
                    Selected = e == exame.Endereco
                });

            return View(exame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,DependenteId,MedicoId,ClinicaId,DataExame,Status,TipoExame,Endereco")] Exame exame)
        {
            if (id != exame.Id)
            {
                return NotFound();
            }

            if (!IsValidExameDate(exame.DataExame))
            {
                ModelState.AddModelError("DataExame", "O exame só pode ser agendado de segunda a sexta entre 07h e 18h, e aos sábados de 08h às 12h.");
            }

            // Validar a existência da clínica
            if (!_context.Clinicas.Any(c => c.Id == exame.ClinicaId))
            {
                ModelState.AddModelError("ClinicaId", "A clínica selecionada não é válida.");
            }

            if (ModelState.IsValid)
            {
                // Certifique-se de que o DependenteId seja nulo se não for selecionado
                if (exame.DependenteId == 0)
                {
                    exame.DependenteId = null;
                }

                _context.Update(exame);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", exame.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", exame.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", exame.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", exame.ClinicaId);

            return View(exame);
        }

        // GET: Exames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames
                .Include(e => e.Paciente)
                .Include(e => e.Dependente)
                .Include(e => e.Clinica)
                .Include(e => e.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // GET: Exames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames
                .Include(e => e.Paciente)
                .Include(e => e.Dependente)
                .Include(e => e.Clinica)
                .Include(e => e.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exame = await _context.Exames.FindAsync(id);

            if (exame != null)
            {
                _context.Exames.Remove(exame);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ExameExists(int id)
        {
            return _context.Exames.Any(e => e.Id == id);
        }

        // Método para validar a data do exame
        private bool IsValidExameDate(DateTime dataExame)
        {
            if (dataExame.DayOfWeek == DayOfWeek.Sunday)
            {
                // Não é possível agendar exames aos domingos
                return false;
            }

            if (dataExame.DayOfWeek == DayOfWeek.Saturday)
            {
                // Aos sábados, só é possível agendar de 08h às 12h
                return dataExame.TimeOfDay >= new TimeSpan(8, 0, 0) && dataExame.TimeOfDay <= new TimeSpan(12, 0, 0);
            }

            // De segunda a sexta, é possível agendar de 07h às 18h
            return dataExame.TimeOfDay >= new TimeSpan(7, 0, 0) && dataExame.TimeOfDay <= new TimeSpan(18, 0, 0);
        }
    }
}
