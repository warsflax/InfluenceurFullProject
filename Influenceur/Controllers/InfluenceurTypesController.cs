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
    public class InfluenceurTypesController : Controller
    {
        private readonly MyAppContext _context;

        public InfluenceurTypesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: InfluenceurTypes
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.influenceurs.Include(i => i.User);
            return View(await myAppContext.ToListAsync());
        }

        // GET: InfluenceurTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influenceurType = await _context.influenceurs
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (influenceurType == null)
            {
                return NotFound();
            }

            return View(influenceurType);
        }

        // GET: InfluenceurTypes/Create
        public IActionResult Create(int userId)
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewBag.UserId = userId;
            return View();
        }

        // POST: InfluenceurTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SocialMedia,FollowersNumber,categorie,EngagementRate,UserId")] InfluenceurType influenceurType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(influenceurType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", influenceurType.UserId);
            return View(influenceurType);
        }

        // GET: InfluenceurTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influenceurType = await _context.influenceurs.FindAsync(id);
            if (influenceurType == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", influenceurType.UserId);
            return View(influenceurType);
        }

        // POST: InfluenceurTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SocialMedia,FollowersNumber,categorie,EngagementRate,UserId")] InfluenceurType influenceurType)
        {
            if (id != influenceurType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(influenceurType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfluenceurTypeExists(influenceurType.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", influenceurType.UserId);
            return View(influenceurType);
        }

        // GET: InfluenceurTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var influenceurType = await _context.influenceurs
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (influenceurType == null)
            {
                return NotFound();
            }

            return View(influenceurType);
        }

        // POST: InfluenceurTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var influenceurType = await _context.influenceurs.FindAsync(id);
            if (influenceurType != null)
            {
                _context.influenceurs.Remove(influenceurType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfluenceurTypeExists(int id)
        {
            return _context.influenceurs.Any(e => e.Id == id);
        }
    }
}
