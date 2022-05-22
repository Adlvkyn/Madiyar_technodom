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
    public class PhonesController : Controller
    {
        private readonly TechnodomContext _context;

        public PhonesController(TechnodomContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
              return _context.Phones != null ? 
                          View(await _context.Phones.ToListAsync()) :
                          Problem("Entity set 'TechnodomContext.Phones'  is null.");
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phones = await _context.Phones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phones == null)
            {
                return NotFound();
            }

            return View(phones);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Storage,AddDate")] Phones phones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phones);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phones = await _context.Phones.FindAsync(id);
            if (phones == null)
            {
                return NotFound();
            }
            return View(phones);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Storage,AddDate")] Phones phones)
        {
            if (id != phones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhonesExists(phones.Id))
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
            return View(phones);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phones = await _context.Phones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phones == null)
            {
                return NotFound();
            }

            return View(phones);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phones == null)
            {
                return Problem("Entity set 'TechnodomContext.Phones'  is null.");
            }
            var phones = await _context.Phones.FindAsync(id);
            if (phones != null)
            {
                _context.Phones.Remove(phones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhonesExists(int id)
        {
          return (_context.Phones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
