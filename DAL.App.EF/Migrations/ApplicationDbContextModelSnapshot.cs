﻿// <auto-generated />
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ApplicationUser", b =>
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogCategoryId");

                    b.Property<string>("BlogDescription")
                        .HasMaxLength(1024);

                    b.Property<string>("BlogTitle")
                        .HasMaxLength(128);

                    b.Property<int>("Rating");

                    b.HasKey("BlogId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogCategoryId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Domain.BlogCategory", b =>
                {
                    b.Property<int>("BlogCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("BlogCategoryName")
                        .HasMaxLength(128);

                    b.HasKey("BlogCategoryId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("BlogCategories");
                });

            modelBuilder.Entity("Domain.BlogComment", b =>
                {
                    b.Property<int>("BlogCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("BlogCommentContent")
                        .HasMaxLength(640);

                    b.Property<DateTime>("BlogCommentPostedTime");

                    b.Property<int?>("BlogId");

                    b.HasKey("BlogCommentId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogComments");
                });

            modelBuilder.Entity("Domain.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogId");

                    b.Property<string>("BlogPostContent")
                        .HasMaxLength(5120);

                    b.Property<DateTime>("BlogPostPostedTime");

                    b.Property<string>("BlogPostTitle")
                        .HasMaxLength(128);

                    b.HasKey("BlogPostId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Domain.BlogPostComment", b =>
                {
                    b.Property<int>("BlogPostCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("BlogPostCommentContent")
                        .HasMaxLength(640);

                    b.Property<DateTime>("BlogPostCommentPostedTime");

                    b.Property<int?>("BlogPostId");

                    b.HasKey("BlogPostCommentId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("BlogPostComments");
                });

            modelBuilder.Entity("Domain.FavoriteCategory", b =>
                {
                    b.Property<int>("FavoriteCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogCategoryId");

                    b.HasKey("FavoriteCategoryId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogCategoryId");

                    b.ToTable("FavoriteCategories");
                });

            modelBuilder.Entity("Domain.FollowedBlog", b =>
                {
                    b.Property<int>("FollowedBlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogId");

                    b.Property<DateTime>("FollowedBlogTime");

                    b.HasKey("FollowedBlogId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogId");

                    b.ToTable("FollowedBlogs");
                });

            modelBuilder.Entity("Domain.LikedBlog", b =>
                {
                    b.Property<int>("LikedBlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogId");

                    b.Property<DateTime>("LikedBlogTime");

                    b.HasKey("LikedBlogId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogId");

                    b.ToTable("LikedBlogs");
                });

            modelBuilder.Entity("Domain.LikedBlogPost", b =>
                {
                    b.Property<int>("LikedBlogPostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("BlogPostId");

                    b.Property<DateTime>("LikedBlogPostTime");

                    b.HasKey("LikedBlogPostId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("LikedBlogPosts");
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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

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

            modelBuilder.Entity("Domain.Blog", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.BlogCategory", "BlogCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("BlogCategoryId");
                });

            modelBuilder.Entity("Domain.BlogCategory", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Domain.BlogComment", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Blog", "Blog")
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("Domain.BlogPost", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Blog", "Blog")
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("Domain.BlogPostComment", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.BlogPost", "BlogPost")
                        .WithMany("BlogPostComments")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("Domain.FavoriteCategory", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("FavoriteCategories")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.BlogCategory", "BlogCategory")
                        .WithMany()
                        .HasForeignKey("BlogCategoryId");
                });

            modelBuilder.Entity("Domain.FollowedBlog", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("FollowedBlogs")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("Domain.LikedBlog", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("LikedBlogs")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("Domain.LikedBlogPost", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("LikedBlogPosts")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.BlogPost", "BlogPost")
                        .WithMany()
                        .HasForeignKey("BlogPostId");
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
                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser")
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

                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
