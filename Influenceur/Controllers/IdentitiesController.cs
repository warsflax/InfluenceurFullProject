using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Influenceur.Data;
using Influenceur.Models;
using Influenceur.Services;

namespace Influenceur.Controllers
{
    public class IdentitiesController : Controller
    {
        private readonly MyAppContext _context;
        private readonly ILogger<IdentitiesController> _logger;

        public IdentitiesController(MyAppContext context, ILogger<IdentitiesController> logger )
        {
            _context = context;
            _logger = logger;
          
        }

        // GET: Identities
        public async Task<IActionResult> Index()
        {
            var myAppContext = _context.Identities.Include(i => i.User);
            return View(await myAppContext.ToListAsync());
        }

        // GET: Identities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.Identities
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
        public async Task<IActionResult> Create([Bind("UserId,IdType,IdRectoImage,IdVersoImage,SelfiImage")] Identity identity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Vérifier que SelfiImage a bien été capturée et envoyée
                    if (identity.SelfiImage != null)
                    {
                        // Sauvegarde de l'image
                        identity.SelfiUrl = await FileHelper.SaveFileAsync(identity.SelfiImage, "assets/Id");
                    }

                    if (identity.IdRectoImage != null)
                    {
                        identity.IdRectoUrl = await FileHelper.SaveFileAsync(identity.IdRectoImage, "assets/Id");
                    }
                    if (identity.IdVersoImage != null)
                    {
                        identity.IdVersoUrl = await FileHelper.SaveFileAsync(identity.IdVersoImage, "assets/Id");
                    }

                    // Ajouter l'entité Identity
                    _context.Add(identity);
                    await _context.SaveChangesAsync();

                    // Après la création de l'identité, mettre à jour le statut de l'utilisateur
                    var user = await _context.Users.FindAsync(identity.UserId);
                    if (user != null)
                    {
                        user.Status = "ID to verify"; // Définir le statut de l'utilisateur
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("Login", "Account");
                }

                // Si le modèle n'est pas valide, retourner à la vue avec les erreurs
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", identity.UserId);
                return View(identity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la création de l'identité");

                // Ajouter un message d'erreur générique au ModelState pour l'afficher dans la vue
                ModelState.AddModelError(string.Empty, "Une erreur s'est produite lors de la création. Veuillez réessayer.");

                // Retourner à la vue avec le modèle et les erreurs
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", identity.UserId);
                return View(identity);
            }
        }

        // GET: Identities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.Identities.FindAsync(id);
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

            var identity = await _context.Identities
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
            var identity = await _context.Identities.FindAsync(id);
            if (identity != null)
            {
                _context.Identities.Remove(identity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityExists(int id)
        {
            return _context.Identities.Any(e => e.Id == id);
        }
    }
}
