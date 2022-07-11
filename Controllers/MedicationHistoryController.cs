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
    public class MedicationHistoryController : Controller
    {
        private readonly Context _context;

        public MedicationHistoryController(Context context)
        {
            _context = context;
        }

        // GET: MedicationHistory
        public async Task<IActionResult> Index()
        {
              return _context.MedicationHistories != null ? 
                          View(await _context.MedicationHistories.ToListAsync()) :
                          Problem("Entity set 'Context.MedicationHistories'  is null.");
        }

        // GET: MedicationHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationHistories == null)
            {
                return NotFound();
            }

            var medicationHistory = await _context.MedicationHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medicationHistory == null)
            {
                return NotFound();
            }

            return View(medicationHistory);
        }

        // GET: MedicationHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicationHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Dosage,Brand,Form,MedicationAmount")] MedicationHistory medicationHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicationHistory);
        }

        // GET: MedicationHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationHistories == null)
            {
                return NotFound();
            }

            var medicationHistory = await _context.MedicationHistories.FindAsync(id);
            if (medicationHistory == null)
            {
                return NotFound();
            }
            return View(medicationHistory);
        }

        // POST: MedicationHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Dosage,Brand,Form,MedicationAmount")] MedicationHistory medicationHistory)
        {
            if (id != medicationHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationHistoryExists(medicationHistory.ID))
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
            return View(medicationHistory);
        }

        // GET: MedicationHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationHistories == null)
            {
                return NotFound();
            }

            var medicationHistory = await _context.MedicationHistories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medicationHistory == null)
            {
                return NotFound();
            }

            return View(medicationHistory);
        }

        // POST: MedicationHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationHistories == null)
            {
                return Problem("Entity set 'Context.MedicationHistories'  is null.");
            }
            var medicationHistory = await _context.MedicationHistories.FindAsync(id);
            if (medicationHistory != null)
            {
                _context.MedicationHistories.Remove(medicationHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationHistoryExists(int id)
        {
          return (_context.MedicationHistories?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
