using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TapLinko.Models;

namespace TapLinko.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<LinkPage> LinkPages { get; set; }
        public DbSet<LinkItem> LinkItems { get; set; }
        public DbSet<ClickEvent> ClickEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LinkPage>()
                .HasOne(c => c.User)
                .WithOne(c => c.LinkPage)
                .HasForeignKey<LinkPage>(c => c.UserId);

            builder.Entity<LinkItem>()
                .HasOne(c => c.LinkPage)
                .WithMany(c => c.LinkItems)
                .HasForeignKey(c => c.LinkPageId);

            builder.Entity<ClickEvent>()
                .HasOne(c => c.LinkItem)
                .WithMany(c => c.ClickEvents)
                .HasForeignKey(c => c.LinkItemId);

            // Seed a test user
            builder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Alice Nguyen",
                    Email = "alice@example.com",
                    Password = "123456" // Just for dev/testing (plain text!)
                }
            );

            // Seed a link page for Alice
            builder.Entity<LinkPage>().HasData(
                new LinkPage
                {
                    LinkPageId = 1,
                    UserId = 1,
                    LinkPageTitle = "Alice's Bio",
                    Bio = "Welcome to my page! 💖",
                    ProfileImageUrl = "https://example.com/images/alice-profile.png",
                    BannerImageUrl = "https://example.com/images/banner.png"
                }
            );

        }

    }
}
