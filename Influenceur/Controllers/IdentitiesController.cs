using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Influenceur.Data;
using Influenceur.Models;

namespace Influenceur.Controllers
{
    public class IdentitiesController : Controller
    {
        private readonly MyAppContext _context;

        public IdentitiesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Identities
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.identities.Include(i => i.User);
            return View(await myAppContext.ToListAsync());
        }

        // GET: Identities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.identities
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identity == null)
            {
                return NotFound();
            }

            return View(identity);
        }

        // GET: Identities/Create
        public IActionResult Create(int userId)
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Identities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdType,IdRectoUrl,IdVersoUrl,UserId")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // GET: Identities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.identities.FindAsync(id);
            if (identity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // POST: Identities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdType,IdRectoUrl,IdVersoUrl,UserId")] Identity identity)
        {
            if (id != identity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityExists(identity.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // GET: Identities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.identities
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identity == null)
            {
                return NotFound();
            }

            return View(identity);
        }

        // POST: Identities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identity = await _context.identities.FindAsync(id);
            if (identity != null)
            {
                _context.identities.Remove(identity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityExists(int id)
        {
            return _context.identities.Any(e => e.Id == id);
        }
    }
}
