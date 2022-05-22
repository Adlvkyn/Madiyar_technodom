using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Technodom.Data;
using Technodom.Models;

namespace Technodom.Controllers
{
    public class TelevisorsController : Controller
    {
        private readonly TechnodomContext _context;

        public TelevisorsController(TechnodomContext context)
        {
            _context = context;
        }

        // GET: Televisors
        public async Task<IActionResult> Index()
        {
              return _context.Televisors != null ? 
                          View(await _context.Televisors.ToListAsync()) :
                          Problem("Entity set 'TechnodomContext.Televisors'  is null.");
        }

        // GET: Televisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Televisors == null)
            {
                return NotFound();
            }

            var televisors = await _context.Televisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (televisors == null)
            {
                return NotFound();
            }

            return View(televisors);
        }

        // GET: Televisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Televisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Diagonal,AddDate")] Televisors televisors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(televisors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(televisors);
        }

        // GET: Televisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Televisors == null)
            {
                return NotFound();
            }

            var televisors = await _context.Televisors.FindAsync(id);
            if (televisors == null)
            {
                return NotFound();
            }
            return View(televisors);
        }

        // POST: Televisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Diagonal,AddDate")] Televisors televisors)
        {
            if (id != televisors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(televisors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelevisorsExists(televisors.Id))
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
            return View(televisors);
        }

        // GET: Televisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Televisors == null)
            {
                return NotFound();
            }

            var televisors = await _context.Televisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (televisors == null)
            {
                return NotFound();
            }

            return View(televisors);
        }

        // POST: Televisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Televisors == null)
            {
                return Problem("Entity set 'TechnodomContext.Televisors'  is null.");
            }
            var televisors = await _context.Televisors.FindAsync(id);
            if (televisors != null)
            {
                _context.Televisors.Remove(televisors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelevisorsExists(int id)
        {
          return (_context.Televisors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
