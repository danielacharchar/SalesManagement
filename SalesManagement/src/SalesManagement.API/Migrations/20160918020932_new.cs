using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesManagement.API.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 9, 17, 23, 9, 31, 327, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2016, 9, 17, 22, 38, 51, 769, DateTimeKind.Local));
        }
    }
}
