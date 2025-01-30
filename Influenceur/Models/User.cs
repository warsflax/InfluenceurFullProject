using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom complet est requis.")]
        public string? FullName { get; set; }

        public string? UserType { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "Format d'email invalide.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? ProfilUrl { get; set; }

        public string? Adresse { get; set; }
        public string? Complement_adresse { get; set; }
        public string? Code_postale { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone_number { get; set; }
        public string? Sexe { get; set; }
        public string? Language { get; set; }
        public string Role { get; set; } = "User";
        public string Status { get; set; } = "Inactive";
        public DateTime? Date_naissance { get; set; }
        public DateTime? CreatedDate { get; set; }

       
        public Sponsor? Sponsor { get; set; }
        
        public List<SocialMediaAccount>? SocialMediaAccounts { get; set; }

        public Identity? Identity { get; set; }
        [NotMapped] // Ne pas mapper cette propriété dans la base de données
        public IFormFile? ProfilImage { get; set; }
         [Required(ErrorMessage = "Veuillez confirmer votre mot de passe.")]
    [Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identiques.")]
    [DataType(DataType.Password)]
        [NotMapped]
        public string? CPassword { get; set; }
        // Constructeur pour assurer les valeurs par défaut
        public User()
        {
            Role = "User";
            Status = "Inactive";
        }
    }

}
