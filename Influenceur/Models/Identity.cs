using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class Identity
    {
        public int Id { get; set; }
        public string IdType { get; set; }
        public string IdRectoUrl { get; set; }
        public string IdVersoUrl { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }  

    }
}
