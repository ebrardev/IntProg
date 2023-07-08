using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using IntProg.Models;

namespace IntProg.Controllers
{
    [Authorize]
    public class AktorsController : Controller
    {
        private readonly tiyatroContext _context;

        public AktorsController(tiyatroContext context)
        {
            _context = context;
        }

        // GET: Aktors
        public async Task<IActionResult> Index()
        {
            var tiyatroContext = _context.Aktors.Include(a => a.Gosteri);
            return View(await tiyatroContext.ToListAsync());
        }

        // GET: Aktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aktors == null)
            {
                return NotFound();
            }

            var aktor = await _context.Aktors
                .Include(a => a.Gosteri)
                .FirstOrDefaultAsync(m => m.AktorId == id);
            if (aktor == null)
            {
                return NotFound();
            }

            return View(aktor);
        }

        // GET: Aktors/Create
        public IActionResult Create()
        {
            ViewData["GosteriId"] = new SelectList(_context.Gosteris, "GosteriId", "GosteriAd");
            return View();
        }

        // POST: Aktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AktorId,AktorAd,SonGosteri,GosteriId,AktorResim")] Aktor aktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GosteriId"] = new SelectList(_context.Gosteris, "GosteriId", "GosteriId", aktor.GosteriId);
            return View(aktor);
        }

        // GET: Aktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aktors == null)
            {
                return NotFound();
            }

            var aktor = await _context.Aktors.FindAsync(id);
            if (aktor == null)
            {
                return NotFound();
            }
            ViewData["GosteriId"] = new SelectList(_context.Gosteris, "GosteriId", "GosteriId", aktor.GosteriId);
            return View(aktor);
        }

        // POST: Aktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AktorId,AktorAd,SonGosteri,GosteriId,AktorResim")] Aktor aktor)
        {
            if (id != aktor.AktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktorExists(aktor.AktorId))
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
            ViewData["GosteriId"] = new SelectList(_context.Gosteris, "GosteriId", "GosteriId", aktor.GosteriId);
            return View(aktor);
        }

        // GET: Aktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aktors == null)
            {
                return NotFound();
            }

            var aktor = await _context.Aktors
                .Include(a => a.Gosteri)
                .FirstOrDefaultAsync(m => m.AktorId == id);
            if (aktor == null)
            {
                return NotFound();
            }

            return View(aktor);
        }

        // POST: Aktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aktors == null)
            {
                return Problem("Entity set 'tiyatroContext.Aktors'  is null.");
            }
            var aktor = await _context.Aktors.FindAsync(id);
            if (aktor != null)
            {
                _context.Aktors.Remove(aktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktorExists(int id)
        {
            return (_context.Aktors?.Any(e => e.AktorId == id)).GetValueOrDefault();
        }
    }
}
