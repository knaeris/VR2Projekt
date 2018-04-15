using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VR2Identity.Data;
using VR2Identity.Models;

namespace VR2Identity.Controllers
{
    [Authorize]
    public class FooBarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FooBarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: FooBars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FooBars.Include(f => f.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FooBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _context.FooBars
                .Include(f => f.ApplicationUser)
                .SingleOrDefaultAsync(m => m.FooBarId == id);
            if (fooBar == null)
            {
                return NotFound();
            }

            return View(fooBar);
        }

        // GET: FooBars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooBars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FooBarId,FooBarName")] FooBar fooBar)
        {
            fooBar.ApplicationUserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _context.Add(fooBar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fooBar);
        }

        // GET: FooBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _context.FooBars
                .SingleOrDefaultAsync(m => m.FooBarId == id && m.ApplicationUserId == User.Identity.GetUserId());
            if (fooBar == null)
            {
                return NotFound();
            }
            return View(fooBar);
        }

        // POST: FooBars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FooBarId,FooBarName")] FooBar fooBar)
        {
            if (id != fooBar.FooBarId)
            {
                return NotFound();
            }
            fooBar.ApplicationUserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fooBar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooBarExists(fooBar.FooBarId))
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
            return View(fooBar);
        }

        // GET: FooBars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fooBar = await _context.FooBars
                .Include(f => f.ApplicationUser)
                .SingleOrDefaultAsync(m => m.FooBarId == id);
            if (fooBar == null)
            {
                return NotFound();
            }

            return View(fooBar);
        }

        // POST: FooBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fooBar = await _context.FooBars.SingleOrDefaultAsync(m => m.FooBarId == id);
            _context.FooBars.Remove(fooBar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooBarExists(int id)
        {
            return _context.FooBars.Any(e => e.FooBarId == id);
        }
    }
}
