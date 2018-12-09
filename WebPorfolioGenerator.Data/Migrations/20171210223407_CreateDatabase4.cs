using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebPorfolioGenerator.Data.Migrations
{
    public partial class CreateDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "ExtBackgroundImage",
                table: "Portfolios",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtBackgroundImage",
                table: "Portfolios");

            migrationBuilder.AddColumn<byte[]>(
                name: "BackgroundImage",
                table: "Portfolios",
                maxLength: 8000,
                nullable: true);
        }
    }
}
