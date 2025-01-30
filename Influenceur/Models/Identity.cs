using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class Identity
    {
        public int Id { get; set; }
        public string? IdType { get; set; }
        public string? IdRectoUrl { get; set; }
        public string? IdVersoUrl { get; set; }
        public string? SelfiUrl { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        [NotMapped]
        public IFormFile? IdRectoImage { get; set; }
        [NotMapped]
        public IFormFile? IdVersoImage { get; set; }
        [NotMapped]
        public IFormFile? SelfiImage { get; set; }

    }
}
