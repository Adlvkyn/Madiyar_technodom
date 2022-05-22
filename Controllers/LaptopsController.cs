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
    public class LaptopsController : Controller
    {
        private readonly TechnodomContext _context;

        public LaptopsController(TechnodomContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
              return _context.Laptops != null ? 
                          View(await _context.Laptops.ToListAsync()) :
                          Problem("Entity set 'TechnodomContext.Laptops'  is null.");
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptops == null)
            {
                return NotFound();
            }

            return View(laptops);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Storage,AddDate")] Laptops laptops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptops);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops.FindAsync(id);
            if (laptops == null)
            {
                return NotFound();
            }
            return View(laptops);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Storage,AddDate")] Laptops laptops)
        {
            if (id != laptops.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopsExists(laptops.Id))
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
            return View(laptops);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptops == null)
            {
                return NotFound();
            }

            return View(laptops);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptops == null)
            {
                return Problem("Entity set 'TechnodomContext.Laptops'  is null.");
            }
            var laptops = await _context.Laptops.FindAsync(id);
            if (laptops != null)
            {
                _context.Laptops.Remove(laptops);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopsExists(int id)
        {
          return (_context.Laptops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
