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
    public class DoctorsAppointmentController : Controller
    {
        private readonly Context _context;

        public DoctorsAppointmentController(Context context)
        {
            _context = context;
        }

        // GET: DoctorsAppointment
        public async Task<IActionResult> Index()
        {
              return _context.DoctorsAppointments != null ? 
                          View(await _context.DoctorsAppointments.ToListAsync()) :
                          Problem("Entity set 'Context.DoctorsAppointments'  is null.");
        }

        // GET: DoctorsAppointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorsAppointments == null)
            {
                return NotFound();
            }

            var doctorsAppointment = await _context.DoctorsAppointments
                .FirstOrDefaultAsync(m => m.IDVisit == id);
            if (doctorsAppointment == null)
            {
                return NotFound();
            }

            return View(doctorsAppointment);
        }

        // GET: DoctorsAppointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsAppointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDVisit,HospitalName,DoctorName,AppointmentDate,Address")] DoctorsAppointment doctorsAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorsAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsAppointment);
        }

        // GET: DoctorsAppointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorsAppointments == null)
            {
                return NotFound();
            }

            var doctorsAppointment = await _context.DoctorsAppointments.FindAsync(id);
            if (doctorsAppointment == null)
            {
                return NotFound();
            }
            return View(doctorsAppointment);
        }

        // POST: DoctorsAppointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDVisit,HospitalName,DoctorName,AppointmentDate,Address")] DoctorsAppointment doctorsAppointment)
        {
            if (id != doctorsAppointment.IDVisit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorsAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsAppointmentExists(doctorsAppointment.IDVisit))
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
            return View(doctorsAppointment);
        }

        // GET: DoctorsAppointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorsAppointments == null)
            {
                return NotFound();
            }

            var doctorsAppointment = await _context.DoctorsAppointments
                .FirstOrDefaultAsync(m => m.IDVisit == id);
            if (doctorsAppointment == null)
            {
                return NotFound();
            }

            return View(doctorsAppointment);
        }

        // POST: DoctorsAppointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorsAppointments == null)
            {
                return Problem("Entity set 'Context.DoctorsAppointments'  is null.");
            }
            var doctorsAppointment = await _context.DoctorsAppointments.FindAsync(id);
            if (doctorsAppointment != null)
            {
                _context.DoctorsAppointments.Remove(doctorsAppointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsAppointmentExists(int id)
        {
          return (_context.DoctorsAppointments?.Any(e => e.IDVisit == id)).GetValueOrDefault();
        }
    }
}
