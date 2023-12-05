using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var pacienteId = _context.Pacientes
            .Where(p => p.Usuario.Email == userEmail)
            .Select(p => p.Id)
            .FirstOrDefault();

        ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", pacienteId);
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,PacienteId")] Dependente dependente)
    {
        if (ModelState.IsValid)
        {
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,PacienteId")] Dependente dependente)
    {
        if (id != dependente.Id)
        {
            return NotFound();
        }

        ModelState.Remove("PacienteId");

        if (ModelState.IsValid)
        {
            try
            {
                var originalDependente = await _context.Dependentes.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                dependente.PacienteId = originalDependente.PacienteId;

                _context.Update(dependente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Pacientes");
        }

        ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Id", dependente.PacienteId);
        return View(dependente);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Dependentes == null)
        {
            return Problem("Entity set 'AppDbContext.Dependentes' is null.");
        }

        var dependente = await _context.Dependentes.FindAsync(id);

        if (dependente == null)
        {
            return NotFound();
        }

        try
        {
            var pacienteId = dependente.PacienteId; // Captura o ID do paciente associado antes de excluir o dependente
            _context.Dependentes.Remove(dependente);
            await _context.SaveChangesAsync();

            // Redireciona diretamente para a lista de dependentes no paciente após a exclusão do dependente
            return RedirectToAction("Index", "Dependentes", new { id = pacienteId });
        }
        catch (DbUpdateConcurrencyException)
        {
            return RedirectToAction("Index", "Pacientes");
        }
    }
}
