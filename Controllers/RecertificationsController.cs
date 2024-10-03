using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseManagementPortal.Data;
using CaseManagementPortal.Models;

namespace CaseManagementPortal.Controllers
{
    public class RecertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recertifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recertifications.Include(r => r.Case);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recertifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recertification = await _context.Recertifications
                .Include(r => r.Case)
                .FirstOrDefaultAsync(m => m.RecertificationId == id);
            if (recertification == null)
            {
                return NotFound();
            }

            return View(recertification);
        }

        // GET: Recertifications/Create
        public IActionResult Create()
        {
            ViewData["CaseId"] = new SelectList(_context.Cases, "CaseId", "CaseId");
            return View();
        }

        // POST: Recertifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecertificationId,RecertificationDate,RecertificationStatus,CaseId")] Recertification recertification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recertification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaseId"] = new SelectList(_context.Cases, "CaseId", "CaseId", recertification.CaseId);
            return View(recertification);
        }

        // GET: Recertifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recertification = await _context.Recertifications.FindAsync(id);
            if (recertification == null)
            {
                return NotFound();
            }
            ViewData["CaseId"] = new SelectList(_context.Cases, "CaseId", "CaseId", recertification.CaseId);
            return View(recertification);
        }

        // POST: Recertifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecertificationId,RecertificationDate,RecertificationStatus,CaseId")] Recertification recertification)
        {
            if (id != recertification.RecertificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recertification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecertificationExists(recertification.RecertificationId))
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
            ViewData["CaseId"] = new SelectList(_context.Cases, "CaseId", "CaseId", recertification.CaseId);
            return View(recertification);
        }

        // GET: Recertifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recertification = await _context.Recertifications
                .Include(r => r.Case)
                .FirstOrDefaultAsync(m => m.RecertificationId == id);
            if (recertification == null)
            {
                return NotFound();
            }

            return View(recertification);
        }

        // POST: Recertifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recertification = await _context.Recertifications.FindAsync(id);
            if (recertification != null)
            {
                _context.Recertifications.Remove(recertification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecertificationExists(int id)
        {
            return _context.Recertifications.Any(e => e.RecertificationId == id);
        }
    }
}
