using Influenceur.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
                .HasForeignKey<Sponsor>(s => s.UserId);  // Définir la clé étrangère

            // Relation One-to-One entre User et InfluenceurType
            modelBuilder.Entity<User>()
                .HasOne(u => u.Influenceur)
                .WithOne(i => i.User)
                .HasForeignKey<InfluenceurType>(i => i.UserId); // Définir la clé étrangère

            // Correction : Relation One-to-One entre User et Identity
            modelBuilder.Entity<User>()
                .HasOne(u => u.Identity)
                .WithOne(i => i.User)
                .HasForeignKey<Identity>(i => i.UserId);  // Définir la clé étrangère sur Identity
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Sponsor> sponsors { get; set; }
        public DbSet<InfluenceurType> influenceurs  { get; set; }
        public DbSet<Identity> identities  { get; set; }
    }
}
