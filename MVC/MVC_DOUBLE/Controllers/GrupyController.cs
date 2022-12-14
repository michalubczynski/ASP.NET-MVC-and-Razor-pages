using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_DOUBLE.Models;

namespace MVC_DOUBLE.Controllers
{
    public class GrupyController : Controller
    {
        private readonly DbUczelnia _context;

        public GrupyController(DbUczelnia context)
        {
            _context = context;
        }

        // GET: Grupy
        public async Task<IActionResult> Index()
        {
              return View(await _context.Grupa.ToListAsync());
        }

        // GET: Grupy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa
                .FirstOrDefaultAsync(m => m.GrupaId == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // GET: Grupy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupaId,Nazwa")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupa);
        }

        // GET: Grupy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa.FindAsync(id);
            if (grupa == null)
            {
                return NotFound();
            }
            return View(grupa);
        }

        // POST: Grupy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupaId,Nazwa")] Grupa grupa)
        {
            if (id != grupa.GrupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupaExists(grupa.GrupaId))
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
            return View(grupa);
        }

        // GET: Grupy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grupa == null)
            {
                return NotFound();
            }

            var grupa = await _context.Grupa
                .FirstOrDefaultAsync(m => m.GrupaId == id);
            if (grupa == null)
            {
                return NotFound();
            }

            return View(grupa);
        }

        // POST: Grupy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupa == null)
            {
                return Problem("Entity set 'DbUczelnia.Grupa'  is null.");
            }
            var grupa = await _context.Grupa.FindAsync(id);
            if (grupa != null)
            {
                _context.Grupa.Remove(grupa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupaExists(int id)
        {
          return _context.Grupa.Any(e => e.GrupaId == id);
        }
    }
}
