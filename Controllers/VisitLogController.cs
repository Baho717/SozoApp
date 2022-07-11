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
    public class VisitLogController : Controller
    {
        private readonly Context _context;

        public VisitLogController(Context context)
        {
            _context = context;
        }

        // GET: VisitLog
        public async Task<IActionResult> Index()
        {
              return _context.VisitLogs != null ? 
                          View(await _context.VisitLogs.ToListAsync()) :
                          Problem("Entity set 'Context.VisitLogs'  is null.");
        }

        // GET: VisitLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VisitLogs == null)
            {
                return NotFound();
            }

            var visitLog = await _context.VisitLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitLog == null)
            {
                return NotFound();
            }

            return View(visitLog);
        }

        // GET: VisitLog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AppointmentDate,Notes")] VisitLog visitLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitLog);
        }

        // GET: VisitLog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VisitLogs == null)
            {
                return NotFound();
            }

            var visitLog = await _context.VisitLogs.FindAsync(id);
            if (visitLog == null)
            {
                return NotFound();
            }
            return View(visitLog);
        }

        // POST: VisitLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AppointmentDate,Notes")] VisitLog visitLog)
        {
            if (id != visitLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitLogExists(visitLog.Id))
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
            return View(visitLog);
        }

        // GET: VisitLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VisitLogs == null)
            {
                return NotFound();
            }

            var visitLog = await _context.VisitLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitLog == null)
            {
                return NotFound();
            }

            return View(visitLog);
        }

        // POST: VisitLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VisitLogs == null)
            {
                return Problem("Entity set 'Context.VisitLogs'  is null.");
            }
            var visitLog = await _context.VisitLogs.FindAsync(id);
            if (visitLog != null)
            {
                _context.VisitLogs.Remove(visitLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitLogExists(int id)
        {
          return (_context.VisitLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
