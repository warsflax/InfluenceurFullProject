using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class SocialMediaAccount
    {
        public int Id { get; set; }
        public string? PlatformName { get; set; }
        public string? UserName { get; set; }
        public string? Url { get; set; }
        public int? FollowersCount { get; set; }
        public double? ManRate { get; set; }
        public double? FemaleRate { get; set; }
        public string? TopCities { get; set; }
        public string? TopCountries { get; set; }
        public string? AgeRange { get; set; }
        public string? Langue { get; set; }
        public string? Niches { get; set; }
        public string? Description { get; set; }


        public int UserId { get; set; } 
        [ForeignKey("UserId")]
       public User? User { get; set; }   
    }
}
