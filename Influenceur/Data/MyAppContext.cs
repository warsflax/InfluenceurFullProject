using Influenceur.Models;
using Microsoft.EntityFrameworkCore;

namespace Influenceur.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relation One-to-One entre User et Sponsor
            modelBuilder.Entity<User>()
                .HasOne(u => u.Sponsor)
                .WithOne(s => s.User)
                .HasForeignKey<Sponsor>(s => s.UserId);

            
            // Relation One-to-One entre User et Identity
            modelBuilder.Entity<User>()
                .HasOne(u => u.Identity)
                .WithOne(i => i.User)
                .HasForeignKey<Identity>(i => i.UserId);

            // Relation One-to-Many entre InfluenceurType et SocialMediaAccount
            modelBuilder.Entity<SocialMediaAccount>()
                .HasOne(s => s.User)
                .WithMany(i => i.SocialMediaAccounts)
                .HasForeignKey(s => s.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
