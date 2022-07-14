using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SozoApothecary;
using SozoApothecary.Models;

namespace SozoApothecary.Controllers
{
    public class CurrentMedicationController : Controller
    {
        private readonly Context _context;

        public CurrentMedicationController(Context context)
        {
            _context = context;
        }

        // GET: CurrentMedication
        public async Task<IActionResult> Index()
        {
              return _context.CurrentMedications != null ? 
                          View(await _context.CurrentMedications.ToListAsync()) :
                          Problem("Entity set 'Context.CurrentMedications'  is null.");
        }

        // GET: CurrentMedication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CurrentMedications == null)
            {
                return NotFound();
            }

            var currentMedication = await _context.CurrentMedications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMedication == null)
            {
                return NotFound();
            }

            return View(currentMedication);
        }

        // GET: CurrentMedication/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurrentMedication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CurrentMedication currentMedication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentMedication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentMedication);
        }

        // GET: CurrentMedication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CurrentMedications == null)
            {
                return NotFound();
            }

            var currentMedication = await _context.CurrentMedications.FindAsync(id);
            if (currentMedication == null)
            {
                return NotFound();
            }
            return View(currentMedication);
        }

        // POST: CurrentMedication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CurrentMedication currentMedication)
        {
            if (id != currentMedication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentMedication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentMedicationExists(currentMedication.Id))
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
            return View(currentMedication);
        }

        // GET: CurrentMedication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CurrentMedications == null)
            {
                return NotFound();
            }

            var currentMedication = await _context.CurrentMedications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMedication == null)
            {
                return NotFound();
            }

            return View(currentMedication);
        }

        // POST: CurrentMedication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CurrentMedications == null)
            {
                return Problem("Entity set 'Context.CurrentMedications'  is null.");
            }
            var currentMedication = await _context.CurrentMedications.FindAsync(id);
            if (currentMedication != null)
            {
                _context.CurrentMedications.Remove(currentMedication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentMedicationExists(int id)
        {
          return (_context.CurrentMedications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
