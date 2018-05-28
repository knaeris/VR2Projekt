using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.App.EF.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "BlogCategoryId",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "BlogCategoryId",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
