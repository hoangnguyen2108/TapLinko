using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TapLinko.Models;

namespace TapLinko.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<LinkPage> LinkPages { get; set; }
        public DbSet<LinkItem> LinkItems { get; set; }
        public DbSet<ClickEvent> ClickEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LinkPage>()
                .HasOne(c => c.ApplicationUser)
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
            var hasher1 = new PasswordHasher<ApplicationUser>();
            // Seed a test user
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "989eb43a-82b3-43a2-b29b-1e14488286fe",
                    UserName = "alice@example.com", // Required
                    NormalizedUserName = "ALICE@EXAMPLE.COM", // Required
                    Email = "alice@example.com", // Required
                    NormalizedEmail = "ALICE@EXAMPLE.COM", // Required
                    EmailConfirmed = true,
                    FirstName = "Alice",
                    LastName = "Nguyen",
                    PasswordHash = hasher1.HashPassword(null!, "Password123!") // Required for login
                }
            );

            builder.Entity<IdentityRole>().HasData(
   new IdentityRole
   {
       Id = "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b",
       Name = "Administrator",
       NormalizedName = "ADMINISTRATOR"
   },
   new IdentityRole
   {
       Id = "958e6340-4275-49ed-80ee-2cb5e2fad807",
       Name = "Employee",
       NormalizedName = "EMPLOYEE"
   },
   new IdentityRole
   {
       Id = "f4145e80-361d-4541-b311-9e95b4a95964",
       Name = "Supervisor",
       NormalizedName = "SUPERVISOR"
   });


            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "69321195-8b73-4f1a-919b-e7deee4b3909",
                UserName = "user1admin",
                NormalizedUserName = "USER1admin",
                Email = "user1adin@gmail.com",
                NormalizedEmail = "USER1admin@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "lONGBADAO123@"),
                EmailConfirmed = true,
                FirstName = "Jay",
                LastName = "Van",
                DateofBirth = new DateOnly(1990, 1, 1)

            },
            new ApplicationUser
            {
                Id = "bdee7c76-d0b8-4ff2-908c-f80177687964",
                UserName = "user2sup",
                NormalizedUserName = "USER2SUP",
                Email = "user2sup@gmail.com",
                NormalizedEmail = "USER2SUP@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "lONGBADAO123@"),
                EmailConfirmed = true,
                FirstName = "John",
                LastName = "Doe",
                DateofBirth = new DateOnly(1992, 2, 2)
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "69321195-8b73-4f1a-919b-e7deee4b3909",
                    RoleId = "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b"
                },
                new IdentityUserRole<string>
                {
                    UserId = "bdee7c76-d0b8-4ff2-908c-f80177687964",
                    RoleId = "f4145e80-361d-4541-b311-9e95b4a95964"
                }
            );

            // Seed a link page for Alice
            builder.Entity<LinkPage>().HasData(
                new LinkPage
                {
                    LinkPageId = 1,
                    UserId = "989eb43a-82b3-43a2-b29b-1e14488286fe",
                    LinkPageTitle = "Alice's Bio",
                    Bio = "Welcome to my page! 💖",
                    ProfileImageUrl = "/image/image.jpeg",
                    BannerImageUrl = "https://example.com/images/banner.png"
                }
            );

            // Seed LinkItem entries
            builder.Entity<LinkItem>().HasData(
                new LinkItem
                {
                    LinkItemId = 1,
                    Label = "GitHub",
                    Url = "https://github.com/alice",
                    Order = 1,
                    ClickCount = 0,
                    LinkPageId = 1
                },
                new LinkItem
                {
                    LinkItemId = 2,
                    Label = "Portfolio",
                    Url = "https://alice.dev",
                    Order = 2,
                    ClickCount = 0,
                    LinkPageId = 1
                }

                );

        }

    }
}
