using AppCentre.API.Helpers;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppCentre.API.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp", "ApplicationName" },
                values: new[] { Guid.NewGuid().ToString(), AppCentreRoles.Devoloper, AppCentreRoles.Devoloper, Guid.NewGuid().ToString(), AppCentreRoles.AppName });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp", "ApplicationName" },
                values: new[] { Guid.NewGuid().ToString(), AppCentreRoles.Administrator, AppCentreRoles.Administrator, Guid.NewGuid().ToString(), AppCentreRoles.AppName });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Truncate table AspNetRoles");
        }
    }
}
