using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excersize
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Excersize.Include(e => e.ExcersizeType).Include(e => e.Session);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Excersize/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersize = await _context.Excersize
                .Include(e => e.ExcersizeType)
                .Include(e => e.Session)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excersize == null)
            {
                return NotFound();
            }

            return View(excersize);
        }

        // GET: Excersize/Create
        public IActionResult Create()
        {
            ViewData["ExcersizeTypeId"] = new SelectList(_context.ExcersizeType, "Id", "Name");
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "Start");
            return View();
        }

        // POST: Excersize/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,NumOfSeries,NumOfReps,ExcersizeTypeId,SessionId")] Excersize excersize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excersize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExcersizeTypeId"] = new SelectList(_context.ExcersizeType, "Id", "Id", excersize.ExcersizeTypeId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "Id", excersize.SessionId);
            return View(excersize);
        }

        // GET: Excersize/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersize = await _context.Excersize.FindAsync(id);
            if (excersize == null)
            {
                return NotFound();
            }
            ViewData["ExcersizeTypeId"] = new SelectList(_context.ExcersizeType, "Id", "Id", excersize.ExcersizeTypeId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "Id", excersize.SessionId);
            return View(excersize);
        }

        // POST: Excersize/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Weight,NumOfSeries,NumOfReps,ExcersizeTypeId,SessionId")] Excersize excersize)
        {
            if (id != excersize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excersize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcersizeExists(excersize.Id))
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
            ViewData["ExcersizeTypeId"] = new SelectList(_context.ExcersizeType, "Id", "Id", excersize.ExcersizeTypeId);
            ViewData["SessionId"] = new SelectList(_context.Session, "Id", "Id", excersize.SessionId);
            return View(excersize);
        }

        // GET: Excersize/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersize = await _context.Excersize
                .Include(e => e.ExcersizeType)
                .Include(e => e.Session)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excersize == null)
            {
                return NotFound();
            }

            return View(excersize);
        }

        // POST: Excersize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excersize = await _context.Excersize.FindAsync(id);
            if (excersize != null)
            {
                _context.Excersize.Remove(excersize);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcersizeExists(int id)
        {
            return _context.Excersize.Any(e => e.Id == id);
        }
    }
}
