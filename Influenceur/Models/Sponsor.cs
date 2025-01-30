using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        public string? WebSite { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }


        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }


    }
}
