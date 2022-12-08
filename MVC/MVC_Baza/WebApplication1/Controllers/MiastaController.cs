using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MiastaController : Controller
    {
        private readonly DbKraj _context;

        public MiastaController(DbKraj context)
        {
            _context = context;
        }

        // GET: Miasta
        public async Task<IActionResult> Index()
        {
            var dbKraj = _context.Miasta.Include(m => m.Wojewodztwo);
            return View(await dbKraj.ToListAsync());
        }

        // GET: Miasta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta
                .Include(m => m.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.MiastoId == id);
            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // GET: Miasta/Create
        public IActionResult Create()
        {
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwa, "WojewodzwoId", "Nazwa");
            return View();
        }

        // POST: Miasta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiastoId,Nazwa,IleMieszkancow,WojewodztwoId")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwa, "WojewodzwoId", "Nazwa", miasto.WojewodztwoId);
            return View(miasto);
        }

        // GET: Miasta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta.FindAsync(id);
            if (miasto == null)
            {
                return NotFound();
            }
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwa, "WojewodzwoId", "Nazwa", miasto.WojewodztwoId);
            return View(miasto);
        }

        // POST: Miasta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiastoId,Nazwa,IleMieszkancow,WojewodztwoId")] Miasto miasto)
        {
            if (id != miasto.MiastoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiastoExists(miasto.MiastoId))
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
            ViewData["WojewodztwoId"] = new SelectList(_context.Wojewodztwa, "WojewodzwoId", "WojewodzwoId", miasto.WojewodztwoId);
            return View(miasto);
        }

        // GET: Miasta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miasta == null)
            {
                return NotFound();
            }

            var miasto = await _context.Miasta
                .Include(m => m.Wojewodztwo)
                .FirstOrDefaultAsync(m => m.MiastoId == id);
            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // POST: Miasta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Miasta == null)
            {
                return Problem("Entity set 'DbKraj.Miasta'  is null.");
            }
            var miasto = await _context.Miasta.FindAsync(id);
            if (miasto != null)
            {
                _context.Miasta.Remove(miasto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiastoExists(int id)
        {
          return _context.Miasta.Any(e => e.MiastoId == id);
        }
    }
}
