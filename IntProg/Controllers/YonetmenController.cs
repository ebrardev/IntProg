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
    public class YonetmenController : Controller
    {
        private readonly tiyatroContext _context;

        public YonetmenController(tiyatroContext context)
        {
            _context = context;
        }

        // GET: Yonetmen
        public async Task<IActionResult> Index()
        {
            return _context.Yonetmen != null ?
                        View(await _context.Yonetmen.ToListAsync()) :
                        Problem("Entity set 'tiyatroContext.Yonetmen'  is null.");
        }

        // GET: Yonetmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yonetmen == null)
            {
                return NotFound();
            }

            var yonetman = await _context.Yonetmen
                .FirstOrDefaultAsync(m => m.YonetmenId == id);
            if (yonetman == null)
            {
                return NotFound();
            }

            return View(yonetman);
        }

        // GET: Yonetmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YonetmenId,YonetmenAd,YonetmenMemleket,YonetmenYas")] Yonetman yonetman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetman);
        }

        // GET: Yonetmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yonetmen == null)
            {
                return NotFound();
            }

            var yonetman = await _context.Yonetmen.FindAsync(id);
            if (yonetman == null)
            {
                return NotFound();
            }
            return View(yonetman);
        }

        // POST: Yonetmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YonetmenId,YonetmenAd,YonetmenMemleket,YonetmenYas")] Yonetman yonetman)
        {
            if (id != yonetman.YonetmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmanExists(yonetman.YonetmenId))
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
            return View(yonetman);
        }

        // GET: Yonetmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yonetmen == null)
            {
                return NotFound();
            }

            var yonetman = await _context.Yonetmen
                .FirstOrDefaultAsync(m => m.YonetmenId == id);
            if (yonetman == null)
            {
                return NotFound();
            }

            return View(yonetman);
        }

        // POST: Yonetmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yonetmen == null)
            {
                return Problem("Entity set 'tiyatroContext.Yonetmen'  is null.");
            }
            var yonetman = await _context.Yonetmen.FindAsync(id);
            if (yonetman != null)
            {
                _context.Yonetmen.Remove(yonetman);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmanExists(int id)
        {
            return (_context.Yonetmen?.Any(e => e.YonetmenId == id)).GetValueOrDefault();
        }
    }
}
