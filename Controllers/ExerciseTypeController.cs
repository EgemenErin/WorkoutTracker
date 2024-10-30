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
    public class ExerciseTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excersize
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExcersizeType.ToListAsync());
        }

        // GET: Excersize/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersizeType = await _context.ExcersizeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excersizeType == null)
            {
                return NotFound();
            }

            return View(excersizeType);
        }

        // GET: Excersize/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excersize/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ExcersizeType excersizeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excersizeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excersizeType);
        }

        // GET: Excersize/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersizeType = await _context.ExcersizeType.FindAsync(id);
            if (excersizeType == null)
            {
                return NotFound();
            }
            return View(excersizeType);
        }

        // POST: Excersize/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ExcersizeType excersizeType)
        {
            if (id != excersizeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excersizeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcersizeTypeExists(excersizeType.Id))
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
            return View(excersizeType);
        }

        // GET: Excersize/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excersizeType = await _context.ExcersizeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excersizeType == null)
            {
                return NotFound();
            }

            return View(excersizeType);
        }

        // POST: Excersize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excersizeType = await _context.ExcersizeType.FindAsync(id);
            if (excersizeType != null)
            {
                _context.ExcersizeType.Remove(excersizeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcersizeTypeExists(int id)
        {
            return _context.ExcersizeType.Any(e => e.Id == id);
        }
    }
}
