using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebPorfolioGenerator.Migrations
{
    public partial class CreateDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlBackgroundImage",
                table: "Portfolios");

            migrationBuilder.AddColumn<byte[]>(
                name: "BackgroundImage",
                table: "Portfolios",
                type: "varbinary(8000)",
                maxLength: 8000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "UrlBackgroundImage",
                table: "Portfolios",
                maxLength: 500,
                nullable: true);
        }
    }
}
