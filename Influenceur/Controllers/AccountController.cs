using Influenceur.Data;
using Influenceur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Influenceur.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyAppContext _context;

        public AccountController(MyAppContext context)
        {
            _context = context;
        }

        // Affiche la page de connexion
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Traite le formulaire de connexion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Vérifie si l'utilisateur existe dans la base de données
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Stocke les informations de l'utilisateur dans une session ou un cookie
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("FullName", user.FullName);

                    // Redirige vers une autre page (par exemple la page d'accueil)
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Adresse e-mail ou mot de passe incorrect.");
            }

            return View(model);
        }

        // Déconnexion
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Supprime les données de la session
            return RedirectToAction("Login", "Account");
        }
    }
}
