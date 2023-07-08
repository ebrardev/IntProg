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
    public class TursController : Controller
    {
        private readonly tiyatroContext _context;

        public TursController(tiyatroContext context)
        {
            _context = context;
        }

        // GET: Turs
        public async Task<IActionResult> Index()
        {
            return _context.Turs != null ?
                        View(await _context.Turs.ToListAsync()) :
                        Problem("Entity set 'tiyatroContext.Turs'  is null.");
        }

        // GET: Turs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turs == null)
            {
                return NotFound();
            }

            var tur = await _context.Turs
                .FirstOrDefaultAsync(m => m.TurId == id);
            if (tur == null)
            {
                return NotFound();
            }

            return View(tur);
        }

        // GET: Turs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurId,TurAd")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tur);
        }

        // GET: Turs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turs == null)
            {
                return NotFound();
            }

            var tur = await _context.Turs.FindAsync(id);
            if (tur == null)
            {
                return NotFound();
            }
            return View(tur);
        }

        // POST: Turs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurId,TurAd")] Tur tur)
        {
            if (id != tur.TurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurExists(tur.TurId))
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
            return View(tur);
        }

        // GET: Turs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turs == null)
            {
                return NotFound();
            }

            var tur = await _context.Turs
                .FirstOrDefaultAsync(m => m.TurId == id);
            if (tur == null)
            {
                return NotFound();
            }

            return View(tur);
        }

        // POST: Turs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turs == null)
            {
                return Problem("Entity set 'tiyatroContext.Turs'  is null.");
            }
            var tur = await _context.Turs.FindAsync(id);
            if (tur != null)
            {
                _context.Turs.Remove(tur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurExists(int id)
        {
            return (_context.Turs?.Any(e => e.TurId == id)).GetValueOrDefault();
        }
    }
}
