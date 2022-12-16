using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklep.Models;
using Sklep.ViewModels;

namespace Sklep.Controllers
{
    public class TowaryController : Controller
    {
        private readonly DbSklep _context;

        public TowaryController(DbSklep context)
        {
            _context = context;
        }

        // GET: Towary
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Id = id;
            var gs = new Towary
            {
                Towary_ = await _context.Towary.ToListAsync(),
                SredniaCena = _context.Towary.Average(s=> s.Cena),
                CalkowitaLiczbaTowarow = _context.Towary.Count()
            };
            return View(gs);
        }

        // GET: Towary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Towary == null)
            {
                return NotFound();
            }

            var towar = await _context.Towary
                .FirstOrDefaultAsync(m => m.TowarId == id);
            if (towar == null)
            {
                return NotFound();
            }

            return View(towar);
        }

        // GET: Towary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Towary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TowarId,Nazwa,Producent,Cena,Ilosc")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(towar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(towar);
        }

        // GET: Towary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Towary == null)
            {
                return NotFound();
            }

            var towar = await _context.Towary.FindAsync(id);
            if (towar == null)
            {
                return NotFound();
            }
            return View(towar);
        }

        // POST: Towary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TowarId,Nazwa,Producent,Cena,Ilosc")] Towar towar)
        {
            if (id != towar.TowarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(towar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TowarExists(towar.TowarId))
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
            return View(towar);
        }

        // GET: Towary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Towary == null)
            {
                return NotFound();
            }

            var towar = await _context.Towary
                .FirstOrDefaultAsync(m => m.TowarId == id);
            if (towar == null)
            {
                return NotFound();
            }

            return View(towar);
        }

        // POST: Towary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Towary == null)
            {
                return Problem("Entity set 'DbSklep.Towary'  is null.");
            }
            var towar = await _context.Towary.FindAsync(id);
            if (towar != null)
            {
                _context.Towary.Remove(towar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TowarExists(int id)
        {
          return _context.Towary.Any(e => e.TowarId == id);
        }
    }
}
