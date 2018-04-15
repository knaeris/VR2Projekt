using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.App.EF.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BlogComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BlogCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ApplicationUserId",
                table: "Blogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ApplicationUserId",
                table: "BlogPosts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_ApplicationUserId",
                table: "BlogComments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ApplicationUserId",
                table: "BlogCategories",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_AspNetUsers_ApplicationUserId",
                table: "BlogCategories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_AspNetUsers_ApplicationUserId",
                table: "BlogComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AspNetUsers_ApplicationUserId",
                table: "BlogPosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_ApplicationUserId",
                table: "Blogs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_AspNetUsers_ApplicationUserId",
                table: "BlogCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_AspNetUsers_ApplicationUserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AspNetUsers_ApplicationUserId",
                table: "BlogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_ApplicationUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_ApplicationUserId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategories_ApplicationUserId",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BlogCategories");
        }
    }
}
