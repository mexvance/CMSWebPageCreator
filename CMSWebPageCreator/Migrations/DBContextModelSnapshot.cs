﻿// <auto-generated />
using System;
using CMSWebPageCreator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMSWebPageCreator.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("CMSWebPageCreator.Models.BodyInfo", b =>
                {
                    b.Property<Guid>("BodyItem")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyContent");

                    b.Property<int>("ContentType");

                    b.Property<Guid>("PageCreateParentId");

                    b.Property<Guid?>("PageCreatepageId");

                    b.HasKey("BodyItem");

                    b.HasIndex("PageCreatepageId");

                    b.ToTable("BodyInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.FooterInfo", b =>
                {
                    b.Property<Guid>("FooterItem")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentType");

                    b.Property<string>("FooterContent");

                    b.Property<Guid>("PageCreateParentId");

                    b.Property<Guid?>("PageCreatepageId");

                    b.HasKey("FooterItem");

                    b.HasIndex("PageCreatepageId");

                    b.ToTable("FooterInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.HeaderInfo", b =>
                {
                    b.Property<Guid>("HeaderItem")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContentType");

                    b.Property<string>("HeaderContent");

                    b.Property<Guid>("PageCreateParentId");

                    b.Property<Guid?>("PageCreatepageId");

                    b.HasKey("HeaderItem");

                    b.HasIndex("PageCreatepageId");

                    b.ToTable("HeaderInfo");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.PageCreate", b =>
                {
                    b.Property<Guid>("pageId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MyBodyBodyItem");

                    b.Property<Guid?>("MyFooterFooterItem");

                    b.Property<Guid?>("MyHeaderHeaderItem");

                    b.Property<string>("Title");

                    b.HasKey("pageId");

                    b.HasIndex("MyBodyBodyItem");

                    b.HasIndex("MyFooterFooterItem");

                    b.HasIndex("MyHeaderHeaderItem");

                    b.ToTable("PageCreate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.BodyInfo", b =>
                {
                    b.HasOne("CMSWebPageCreator.Models.PageCreate")
                        .WithMany("BodyItems")
                        .HasForeignKey("PageCreatepageId");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.FooterInfo", b =>
                {
                    b.HasOne("CMSWebPageCreator.Models.PageCreate")
                        .WithMany("FooterItems")
                        .HasForeignKey("PageCreatepageId");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.HeaderInfo", b =>
                {
                    b.HasOne("CMSWebPageCreator.Models.PageCreate")
                        .WithMany("Headers")
                        .HasForeignKey("PageCreatepageId");
                });

            modelBuilder.Entity("CMSWebPageCreator.Models.PageCreate", b =>
                {
                    b.HasOne("CMSWebPageCreator.Models.BodyInfo", "MyBody")
                        .WithMany()
                        .HasForeignKey("MyBodyBodyItem");

                    b.HasOne("CMSWebPageCreator.Models.FooterInfo", "MyFooter")
                        .WithMany()
                        .HasForeignKey("MyFooterFooterItem");

                    b.HasOne("CMSWebPageCreator.Models.HeaderInfo", "MyHeader")
                        .WithMany()
                        .HasForeignKey("MyHeaderHeaderItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
