using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserType  { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ProfilUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

       
        public Sponsor? Sponsor { get; set; }
        public InfluenceurType? Influenceur { get; set; }
        public Identity? Identity { get; set; }
    }
}
