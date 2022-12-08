using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst.Models;

namespace MVC_CodeFirst.Controllers
{
    public class PartieController : Controller
    {
        private readonly DbSejm _context;

        public PartieController(DbSejm context)
        {
            _context = context;
        }

        // GET: Partie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partie.Include(a => a.Poslowie).ToListAsync());
        }

        // GET: Partie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Partie == null)
            {
                return NotFound();
            }

            var partia = await _context.Partie
                .FirstOrDefaultAsync(m => m.PartiaId == id);
            if (partia == null)
            {
                return NotFound();
            }

            return View(partia);
        }

        // GET: Partie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartiaId,Nazwa")] Partia partia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partia);
        }

        // GET: Partie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Partie == null)
            {
                return NotFound();
            }

            var partia = await _context.Partie.FindAsync(id);
            if (partia == null)
            {
                return NotFound();
            }
            return View(partia);
        }

        // POST: Partie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartiaId,Nazwa")] Partia partia)
        {
            if (id != partia.PartiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartiaExists(partia.PartiaId))
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
            return View(partia);
        }

        // GET: Partie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Partie == null)
            {
                return NotFound();
            }

            var partia = await _context.Partie
                .FirstOrDefaultAsync(m => m.PartiaId == id);
            if (partia == null)
            {
                return NotFound();
            }

            return View(partia);
        }

        // POST: Partie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Partie == null)
            {
                return Problem("Entity set 'DbSejm.Partie'  is null.");
            }
            var partia = await _context.Partie.FindAsync(id);
            if (partia != null)
            {
                _context.Partie.Remove(partia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartiaExists(int id)
        {
          return _context.Partie.Any(e => e.PartiaId == id);
        }
    }
}
