using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace medcenter_backend.Controllers
{
    [Authorize(Roles ="Admin")]
    public class InfoExmsController : Controller
    {
        private readonly AppDbContext _context;

        public InfoExmsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InfoExms
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return View(await _context.InfoExms.ToListAsync());
        }

        // GET: InfoExms/Details/5
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

        // GET: InfoExms/Create


        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoExms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: InfoExms/Edit/5
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

        // POST: InfoExms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: InfoExms/Delete/5
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

        // POST: InfoExms/Delete/5
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
