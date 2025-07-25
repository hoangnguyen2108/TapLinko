﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TapLinko.Data;

#nullable disable

namespace TapLinko.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "958e6340-4275-49ed-80ee-2cb5e2fad807",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "f4145e80-361d-4541-b311-9e95b4a95964",
                            Name = "Supervisor",
                            NormalizedName = "SUPERVISOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "69321195-8b73-4f1a-919b-e7deee4b3909",
                            RoleId = "1b1bb66e-6aa2-4728-8b5b-4e6de4fd899b"
                        },
                        new
                        {
                            UserId = "bdee7c76-d0b8-4ff2-908c-f80177687964",
                            RoleId = "f4145e80-361d-4541-b311-9e95b4a95964"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TapLinko.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DateofBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "69321195-8b73-4f1a-919b-e7deee4b3909",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3a6d60c-878d-4fc1-a023-b73ca77a3b6a",
                            DateofBirth = new DateOnly(1990, 1, 1),
                            Email = "user1adin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Jay",
                            LastName = "Van",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1admin@GMAIL.COM",
                            NormalizedUserName = "USER1admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEFPvLSPM0CupfiPTmG4dTISBSFlQ1DRhTuAdm7eGqveojFsji7nfWuXD61E+eDLQsg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b7b886f6-d07a-44e5-b505-a766754debae",
                            TwoFactorEnabled = false,
                            UserName = "user1admin"
                        },
                        new
                        {
                            Id = "bdee7c76-d0b8-4ff2-908c-f80177687964",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5b4b7386-109a-4648-9c81-1be716e6bbe5",
                            DateofBirth = new DateOnly(1992, 2, 2),
                            Email = "user2sup@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2SUP@GMAIL.COM",
                            NormalizedUserName = "USER2SUP",
                            PasswordHash = "AQAAAAIAAYagAAAAEIDz5vA6+ioxsswh1DQSSbZ7j2D/x6ht+un76uIhWRmmrMnWTMXLD83lfTjvjY9m7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c295192e-fc47-48db-a6a2-4ea330ee6fdb",
                            TwoFactorEnabled = false,
                            UserName = "user2sup"
                        });
                });

            modelBuilder.Entity("TapLinko.Models.ClickEvent", b =>
                {
                    b.Property<int>("ClickEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClickEventId"));

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LinkItemId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Timestamp")
                        .HasColumnType("date");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClickEventId");

                    b.HasIndex("LinkItemId");

                    b.ToTable("ClickEvents");
                });

            modelBuilder.Entity("TapLinko.Models.LinkItem", b =>
                {
                    b.Property<int>("LinkItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkItemId"));

                    b.Property<int>("ClickCount")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LinkPageId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkItemId");

                    b.HasIndex("LinkPageId");

                    b.ToTable("LinkItems");

                    b.HasData(
                        new
                        {
                            LinkItemId = 1,
                            ClickCount = 0,
                            Label = "GitHub",
                            LinkPageId = 1,
                            Order = 1,
                            Url = "https://github.com/alice"
                        },
                        new
                        {
                            LinkItemId = 2,
                            ClickCount = 0,
                            Label = "Portfolio",
                            LinkPageId = 1,
                            Order = 2,
                            Url = "https://alice.dev"
                        });
                });

            modelBuilder.Entity("TapLinko.Models.LinkPage", b =>
                {
                    b.Property<int>("LinkPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkPageId"));

                    b.Property<string>("BannerImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkPageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LinkPageId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("LinkPages");

                    b.HasData(
                        new
                        {
                            LinkPageId = 1,
                            BannerImageUrl = "https://example.com/images/banner.png",
                            Bio = "Welcome to my page! 💖",
                            LinkPageTitle = "Alice's Bio",
                            ProfileImageUrl = "/image/image.jpeg",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TapLinko.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Alice Nguyen"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TapLinko.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TapLinko.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TapLinko.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TapLinko.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TapLinko.Models.ClickEvent", b =>
                {
                    b.HasOne("TapLinko.Models.LinkItem", "LinkItem")
                        .WithMany("ClickEvents")
                        .HasForeignKey("LinkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkItem");
                });

            modelBuilder.Entity("TapLinko.Models.LinkItem", b =>
                {
                    b.HasOne("TapLinko.Models.LinkPage", "LinkPage")
                        .WithMany("LinkItems")
                        .HasForeignKey("LinkPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkPage");
                });

            modelBuilder.Entity("TapLinko.Models.LinkPage", b =>
                {
                    b.HasOne("TapLinko.Models.User", "User")
                        .WithOne("LinkPage")
                        .HasForeignKey("TapLinko.Models.LinkPage", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TapLinko.Models.LinkItem", b =>
                {
                    b.Navigation("ClickEvents");
                });

            modelBuilder.Entity("TapLinko.Models.LinkPage", b =>
                {
                    b.Navigation("LinkItems");
                });

            modelBuilder.Entity("TapLinko.Models.User", b =>
                {
                    b.Navigation("LinkPage");
                });
#pragma warning restore 612, 618
        }
    }
}
