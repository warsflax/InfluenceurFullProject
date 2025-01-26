using System.ComponentModel.DataAnnotations.Schema;

namespace Influenceur.Models
{
    public class InfluenceurType 
    {
     
        public int Id { get; set; }
        public string SocialMedia  { get; set; }
        public string FollowersNumber { get; set; }
        public string categorie {  get; set; }
        public double EngagementRate { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

    }
}
