using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.App.EF.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_BlogPosts_BlogPostId",
                table: "BlogPostComments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogPostComments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogComments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_BlogPosts_BlogPostId",
                table: "BlogPostComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_BlogPosts_BlogPostId",
                table: "BlogPostComments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogPostComments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogComments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_BlogPosts_BlogPostId",
                table: "BlogPostComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
