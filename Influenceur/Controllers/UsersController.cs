using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Influenceur.Data;
using Influenceur.Models;
using Influenceur.ViewModel;
using Influenceur.Services;

namespace Influenceur.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyAppContext _context;

        public UsersController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,UserType,Email,Password,ProfilImage,ProfilUrl,Adresse,Complement_adresse,Code_postale,City,Country,Phone_number,Sexe,Language,Role,Status,Date_naissance, CPassword")] User user)
        {
            // Vérification de la correspondance des mots de passe
            if (user.Password != user.CPassword)
            {
                ModelState.AddModelError("CPassword", "Les mots de passe ne sont pas identiques.");
            }

            // Vérification si l'email existe déjà dans la base de données
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Cet email est déjà utilisé.");
            }

            if (ModelState.IsValid)
            {
                if (user.ProfilImage != null)
                {
                    user.ProfilUrl = await FileHelper.SaveFileAsync(user.ProfilImage, "assets/pdp");
                }
                _context.Add(user);
                await _context.SaveChangesAsync();

                // Rediriger en fonction du type d'utilisateur
                switch (user.UserType)
                {
                    case "Influenceur":
                        return RedirectToAction("Create", "SocialMediaAccounts", new { userId = user.Id });

                    case "Sponsor":
                        return RedirectToAction("Create", "Sponsors", new { userId = user.Id });
                }
            }
            return View(user);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,UserType,Email,Password,ProfilUrl,CreatedDate")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
