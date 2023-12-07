using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;

namespace medcenter_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InfoExmsController : Controller
    {
        private readonly AppDbContext _context;

        public InfoExmsController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoExms.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Pesquisar(string termoPesquisa)
        {
            if (string.IsNullOrEmpty(termoPesquisa))
            {
                // Se nenhum termo de pesquisa for fornecido, exibir todos os exames
                return RedirectToAction(nameof(Index));
            }

            var resultados = await _context.InfoExms
                .Where(e => e.Nome.Contains(termoPesquisa) ||
                            e.Description.Contains(termoPesquisa) ||
                            e.Detalhes.Contains(termoPesquisa) ||
                            e.Preparo.Contains(termoPesquisa))
                .ToListAsync();

            return View("Index", resultados);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InfoExms == null)
            {
                return NotFound();
            }

            var infoExm = await _context.InfoExms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoExm == null)
            {
                return NotFound();
            }

            return View(infoExm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Description,Detalhes,Preparo")] InfoExm infoExm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoExm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoExm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InfoExms == null)
            {
                return NotFound();
            }

            var infoExm = await _context.InfoExms.FindAsync(id);
            if (infoExm == null)
            {
                return NotFound();
            }
            return View(infoExm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Description,Detalhes,Preparo")] InfoExm infoExm)
        {
            if (id != infoExm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoExm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExmExists(infoExm.Id))
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
            return View(infoExm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InfoExms == null)
            {
                return NotFound();
            }

            var infoExm = await _context.InfoExms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoExm == null)
            {
                return NotFound();
            }

            return View(infoExm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InfoExms == null)
            {
                return Problem("Entity set 'AppDbContext.InfoExms'  is null.");
            }
            var infoExm = await _context.InfoExms.FindAsync(id);
            if (infoExm != null)
            {
                _context.InfoExms.Remove(infoExm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExmExists(int id)
        {
            return _context.InfoExms.Any(e => e.Id == id);
        }
    }
}
