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
    public class SocialMediaAccountsController : Controller
    {
        private readonly MyAppContext _context;

        public SocialMediaAccountsController(MyAppContext context)
        {
            _context = context;
        }

        // GET: SocialMediaAccounts
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.SocialMediaAccounts.Include(s => s.UserId);
            return View(await myAppContext.ToListAsync());
        }

        // GET: SocialMediaAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccounts
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }

            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Create
        public IActionResult Create(int userId)
        {
            //ViewData["InfluenceurTypeId"] = new SelectList(_context.Influenceurs, "Id", "Id");
            ViewBag.UserId = userId;
            return View();
        }

        // POST: SocialMediaAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlatformName,UserName,Url,FollowersCount,ManRate,FemaleRate,TopCities,TopCountries,AgeRange, UserId , Langue, Niches ,Description, UserId")] SocialMediaAccount socialMediaAccount, string redirectTo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMediaAccount);
                await _context.SaveChangesAsync();
                if (redirectTo == "ADD New Social Media")
                {
                   return RedirectToAction("Create", "SocialMediaAccounts", new { userId = socialMediaAccount.UserId});

                }
                else if (redirectTo == "Next")
                {
                    return RedirectToAction("Create", "Identities", new { userId = socialMediaAccount.UserId });

                }
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", socialMediaAccount.UserId);
            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccounts.FindAsync(id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", socialMediaAccount.UserId);
            return View(socialMediaAccount);
        }

        // POST: SocialMediaAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlatformName,UserName,Url,FollowersCount,ManRate,FemaleRate,TopCities,TopCountries,AgeRange")] SocialMediaAccount socialMediaAccount)
        {
            if (id != socialMediaAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMediaAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaAccountExists(socialMediaAccount.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", socialMediaAccount.UserId);
            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccounts
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }

            return View(socialMediaAccount);
        }

        // POST: SocialMediaAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialMediaAccount = await _context.SocialMediaAccounts.FindAsync(id);
            if (socialMediaAccount != null)
            {
                _context.SocialMediaAccounts.Remove(socialMediaAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaAccountExists(int id)
        {
            return _context.SocialMediaAccounts.Any(e => e.Id == id);
        }
    }
}
