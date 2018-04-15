using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.App.EF.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogComments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogComments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Blogs_BlogId",
                table: "BlogPosts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
