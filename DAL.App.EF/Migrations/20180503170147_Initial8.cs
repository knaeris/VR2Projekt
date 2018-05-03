using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.App.EF.Migrations
{
    public partial class Initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteCategories",
                columns: table => new
                {
                    FavoriteCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BlogCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCategories", x => x.FavoriteCategoryId);
                    table.ForeignKey(
                        name: "FK_FavoriteCategories_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteCategories_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FollowedBlogs",
                columns: table => new
                {
                    FollowedBlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: true),
                    FollowedBlogTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedBlogs", x => x.FollowedBlogId);
                    table.ForeignKey(
                        name: "FK_FollowedBlogs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowedBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikedBlogPosts",
                columns: table => new
                {
                    LikedBlogPostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BlogPostId = table.Column<int>(nullable: true),
                    LikedBlogPostTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedBlogPosts", x => x.LikedBlogPostId);
                    table.ForeignKey(
                        name: "FK_LikedBlogPosts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikedBlogPosts_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "BlogPostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikedBlogs",
                columns: table => new
                {
                    LikedBlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: true),
                    LikedBlogTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedBlogs", x => x.LikedBlogId);
                    table.ForeignKey(
                        name: "FK_LikedBlogs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikedBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCategories_ApplicationUserId",
                table: "FavoriteCategories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCategories_BlogCategoryId",
                table: "FavoriteCategories",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedBlogs_ApplicationUserId",
                table: "FollowedBlogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedBlogs_BlogId",
                table: "FollowedBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedBlogPosts_ApplicationUserId",
                table: "LikedBlogPosts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedBlogPosts_BlogPostId",
                table: "LikedBlogPosts",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedBlogs_ApplicationUserId",
                table: "LikedBlogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedBlogs_BlogId",
                table: "LikedBlogs",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCategories");

            migrationBuilder.DropTable(
                name: "FollowedBlogs");

            migrationBuilder.DropTable(
                name: "LikedBlogPosts");

            migrationBuilder.DropTable(
                name: "LikedBlogs");
        }
    }
}
