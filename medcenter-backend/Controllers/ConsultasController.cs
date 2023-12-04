using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using medcenter_backend.Services;
using System.Configuration;

namespace medcenter_backend.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public ConsultasController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obter o paciente associado ao usuário conectado
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Usuario.Email == userEmail);

            var consultas = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dependente)
                .Include(c => c.Clinica)
                .Include(c => c.Medico)
                .Where(c => c.PacienteId == paciente.Id || c.Dependente.PacienteId == paciente.Id)
                .ToListAsync();

            return View(consultas);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obter o paciente associado ao usuário conectado
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Usuario.Email == userEmail);

            // Obter apenas os dependentes associados ao paciente
            var dependentes = _context.Dependentes
                .Where(d => d.PacienteId == paciente.Id)
                .ToList();

            // Obter apenas os médicos e clínicas associados ao usuário conectado
            var medicos = _context.Medicos.ToList();
            var clinicas = _context.Clinicas.ToList();

            // Criar uma nova consulta com o status "Agendada"
            var novaConsulta = new Consulta
            {
                DataConsulta = DateTime.Now, // Você pode ajustar conforme necessário
                Status = StatusConsulta.Agendada,
                PacienteId = paciente.Id,
                TipoConsulta = TipoConsulta.Presencial // Definir o tipo de consulta aqui
            };

            ViewBag.Pacientes = new SelectList(new List<Paciente> { paciente }, "Id", "Nome", paciente.Id);
            ViewBag.Dependentes = new SelectList(dependentes, "Id", "Nome");
            ViewBag.Medicos = new SelectList(medicos, "Id", "Nome");
            ViewBag.Clinicas = new SelectList(clinicas, "Id", "Nome");

            return View(novaConsulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,DependenteId,MedicoId,ClinicaId,DataConsulta,Status,TipoConsulta")] Consulta consulta)
        {
            // Verificar se a data da consulta está no futuro
            if (consulta.DataConsulta < DateTime.Now)
            {
                ModelState.AddModelError("DataConsulta", "A data da consulta deve ser no futuro.");
            }

            // Verificar restrições de horário
            if (!IsValidAppointmentTime(consulta.DataConsulta))
            {
                ModelState.AddModelError("DataConsulta", "Horário de consulta inválido.");
            }

            if (ModelState.IsValid)
            {
                // Certifica de que o DependenteId seja nulo se não for selecionado
                if (consulta.DependenteId == 0)
                {
                    consulta.DependenteId = null;
                }

                // Ajuste para obter o paciente associado ao usuário conectado
                var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var paciente = _context.Pacientes.Include(p => p.Usuario).FirstOrDefault(p => p.Usuario.Email == userEmail);

                consulta.PacienteId = paciente.Id;

                _context.Add(consulta);
                await _context.SaveChangesAsync();

                // Enviar e-mail de consulta agendada
                string emailSubject = $"Medcenter - Consulta Agendada - {consulta.DataConsulta:dd/MM/yyyy HH:mm}";
                string username = paciente.Nome;
                string emailMessage = $"Olá {username},\n\nSua consulta foi agendada com sucesso. Abaixo estão os detalhes:\n\n";

                emailMessage += $"Paciente: {paciente.Nome}\n";

                if (consulta.DependenteId != null)
                {
                    var dependente = _context.Dependentes.FirstOrDefault(d => d.Id == consulta.DependenteId);
                    emailMessage += $"Dependente: {dependente.Nome}\n";
                }

                var medico = _context.Medicos.FirstOrDefault(m => m.Id == consulta.MedicoId);
                var clinica = _context.Clinicas.FirstOrDefault(c => c.Id == consulta.ClinicaId);

                emailMessage += $"Médico: {medico.Nome}\n";
                emailMessage += $"Clínica: {clinica.Nome}\n";
                emailMessage += $"Horário: {consulta.DataConsulta:dd/MM/yyyy HH:mm}\n\n";

                // Enviar e-mail
                EmailSender emailSender = new EmailSender();
                await emailSender.SendEmail(emailSubject, paciente.Email, username, emailMessage);

                // Criar sala no Google Meet se a consulta for do tipo Online
                if (consulta.TipoConsulta == TipoConsulta.Online)
                {
                    string patientEmail = paciente.Email;
                    string doctorEmail = medico.Email;
                    DateTime meetingStartTime = consulta.DataConsulta;
                    DateTime meetingEndTime = consulta.DataConsulta.AddMinutes(30); // Exemplo: Consulta de 30 minutos

                    // Chamar o método CreateMeeting do GoogleMeetService
                    }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pacientes = new SelectList(_context.Pacientes, "Id", "Nome", consulta.PacienteId);
            ViewBag.Dependentes = new SelectList(_context.Dependentes, "Id", "Nome", consulta.DependenteId);
            ViewBag.Medicos = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoId);
            ViewBag.Clinicas = new SelectList(_context.Clinicas, "Id", "Nome", consulta.ClinicaId);

            return View(consulta);
        }

        // Método auxiliar para verificar restrições de horário
        private bool IsValidAppointmentTime(DateTime dataConsulta)
        {
            // Verificar se é sábado e está entre 08h e 12h
            if (dataConsulta.DayOfWeek == DayOfWeek.Saturday && dataConsulta.TimeOfDay >= TimeSpan.FromHours(8) && dataConsulta.TimeOfDay <= TimeSpan.FromHours(12))
            {
                return true;
            }

            // Verificar se é domingo
            if (dataConsulta.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            // Verificar se é segunda a sexta-feira e está entre 08h e 18h
            if (dataConsulta.DayOfWeek >= DayOfWeek.Monday && dataConsulta.DayOfWeek <= DayOfWeek.Friday && dataConsulta.TimeOfDay >= TimeSpan.FromHours(8) && dataConsulta.TimeOfDay <= TimeSpan.FromHours(18))
            {
                return true;
            }

            return false;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        // GET: Consultas/Cancel/5
        public async Task<IActionResult> Cancel(int? id)
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

        // POST: Consultas/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            // Altera o status para "Cancelada"
            consulta.Status = StatusConsulta.Cancelada;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Consultas/ConsultasMedicos
        public IActionResult ConsultasMedicos(string nomePaciente, string sortOrder)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obter o médico associado ao usuário conectado
            var medico = _context.Medicos.FirstOrDefault(m => m.Usuario.Email == userEmail);

            if (medico == null)
            {
                return View("Index");
            }

            var consultasDoMedico = _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dependente)
                .Include(c => c.Clinica)
                .Include(c => c.Medico)
                .Where(c => c.MedicoId == medico.Id);

            if (!string.IsNullOrEmpty(nomePaciente))
            {
                // Aplicar o filtro pelo nome do paciente
                consultasDoMedico = consultasDoMedico.Where(c => c.Paciente.Nome.Contains(nomePaciente));
            }

            // Aplicar a ordenação
            switch (sortOrder)
            {
                case "DataConsulta_desc":
                    consultasDoMedico = consultasDoMedico.OrderByDescending(c => c.DataConsulta);
                    break;
                case "Paciente.Nome":
                    consultasDoMedico = consultasDoMedico.OrderBy(c => c.Paciente.Nome);
                    break;
                case "Paciente.Nome_desc":
                    consultasDoMedico = consultasDoMedico.OrderByDescending(c => c.Paciente.Nome);
                    break;
                case "Dependente.Nome":
                    consultasDoMedico = consultasDoMedico.OrderBy(c => c.Dependente.Nome);
                    break;
                case "Dependente.Nome_desc":
                    consultasDoMedico = consultasDoMedico.OrderByDescending(c => c.Dependente.Nome);
                    break;
                case "Clinica.Nome":
                    consultasDoMedico = consultasDoMedico.OrderBy(c => c.Clinica.Nome);
                    break;
                case "Clinica.Nome_desc":
                    consultasDoMedico = consultasDoMedico.OrderByDescending(c => c.Clinica.Nome);
                    break;
                case "Status":
                    consultasDoMedico = consultasDoMedico.OrderBy(c => c.Status);
                    break;
                case "Status_desc":
                    consultasDoMedico = consultasDoMedico.OrderByDescending(c => c.Status);
                    break;
                default:
                    consultasDoMedico = consultasDoMedico.OrderBy(c => c.DataConsulta);
                    break;
            }

            var consultasFiltradas = consultasDoMedico.ToList();

            // Adicionar informações de ordenação à ViewBag
            ViewBag.DataConsultaSort = sortOrder == "DataConsulta" ? "DataConsulta_desc" : "DataConsulta";
            ViewBag.NomePacienteSort = sortOrder == "Paciente.Nome" ? "Paciente.Nome_desc" : "Paciente.Nome";
            ViewBag.NomeDependenteSort = sortOrder == "Dependente.Nome" ? "Dependente.Nome_desc" : "Dependente.Nome";
            ViewBag.NomeClinicaSort = sortOrder == "Clinica.Nome" ? "Clinica.Nome_desc" : "Clinica.Nome";
            ViewBag.StatusSort = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.CurrentFilter = nomePaciente;

            return View(consultasFiltradas);
        }

        [HttpGet]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> MarcarComoRealizada(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            // Altera o status para "Realizada"
            consulta.Status = StatusConsulta.Realizada;

            await _context.SaveChangesAsync();
            return RedirectToAction("ConsultasMedicos");
        }

        [HttpPost]  
        [Authorize(Roles = "Medico")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarConsultaComoRealizada(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            // Altera o status para "Realizada"
            consulta.Status = StatusConsulta.Realizada;

            await _context.SaveChangesAsync();
            return RedirectToAction("ConsultasMedicos");
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
