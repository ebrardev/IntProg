using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntProg.Models;
using Microsoft.AspNetCore.Authorization;

namespace IntProg.Controllers
{
    [Authorize]
    public class GosterisController : Controller
    {
        private readonly tiyatroContext _context;

        public GosterisController(tiyatroContext context)
        {
            _context = context;
        }

        // GET: Gosteris
        public async Task<IActionResult> Index()
        {
              return _context.Gosteris != null ? 
                          View(await _context.Gosteris.ToListAsync()) :
                          Problem("Entity set 'tiyatroContext.Gosteris'  is null.");
        }

        // GET: Gosteris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gosteris == null)
            {
                return NotFound();
            }

            var gosteri = await _context.Gosteris
                .FirstOrDefaultAsync(m => m.GosteriId == id);
            if (gosteri == null)
            {
                return NotFound();
            }

            return View(gosteri);
        }

        // GET: Gosteris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gosteris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GosteriId,GosteriAd,GosteriTarih,GosteriYeri")] Gosteri gosteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gosteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gosteri);
        }

        // GET: Gosteris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gosteris == null)
            {
                return NotFound();
            }

            var gosteri = await _context.Gosteris.FindAsync(id);
            if (gosteri == null)
            {
                return NotFound();
            }
            return View(gosteri);
        }

        // POST: Gosteris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GosteriId,GosteriAd,GosteriTarih,GosteriYeri")] Gosteri gosteri)
        {
            if (id != gosteri.GosteriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gosteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GosteriExists(gosteri.GosteriId))
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
            return View(gosteri);
        }

        // GET: Gosteris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gosteris == null)
            {
                return NotFound();
            }

            var gosteri = await _context.Gosteris
                .FirstOrDefaultAsync(m => m.GosteriId == id);
            if (gosteri == null)
            {
                return NotFound();
            }

            return View(gosteri);
        }

        // POST: Gosteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gosteris == null)
            {
                return Problem("Entity set 'tiyatroContext.Gosteris'  is null.");
            }
            var gosteri = await _context.Gosteris.FindAsync(id);
            if (gosteri != null)
            {
                _context.Gosteris.Remove(gosteri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GosteriExists(int id)
        {
          return (_context.Gosteris?.Any(e => e.GosteriId == id)).GetValueOrDefault();
        }
    }
}
