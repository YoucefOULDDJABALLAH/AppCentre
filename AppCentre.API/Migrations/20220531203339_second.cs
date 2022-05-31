using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCentre.API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7504e4b1-0545-47e6-a43f-9a9415120630", "cd9ec744-4db0-4df7-afe5-ba0c5861cd51" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7504e4b1-0545-47e6-a43f-9a9415120630");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd9ec744-4db0-4df7-afe5-ba0c5861cd51");

            migrationBuilder.DeleteData(
                table: "AspNetApplications",
                keyColumn: "ApplicationsID",
                keyValue: "34863c7c-578a-43b4-a54d-8ab1b8c52e33");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "AspNetApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationsName",
                table: "AspNetApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetApplications",
                columns: new[] { "ApplicationsID", "ApplicationsName", "ShortName" },
                values: new object[] { "1624ce4f-be04-4b12-8639-cb211b36f282", "Applications Centre", "AppCentre" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Grade", "LockoutEnabled", "LockoutEnd", "Matricule", "NN", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "Service", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d78d3cc-9171-4513-b639-f3ea026988f9", 0, "2d4e7384-8f78-41c6-b183-4be827408369", "Youcef_OULD_DJABALLAH@AppCentre.DRH", true, 15, false, null, "3K174", 400123, "Youcef", "Youcef_OULD_DJABALLAH@AppCentre.DRH", null, "31uVufYPiSu4aohjRaUSzI7WeY3PSwkPX3pzGg9Grrg=", null, false, "OULD DJABALLAH", "abbbfb76-7edd-4e25-bc47-d2d4c868b869", "16H\\", false, "Youcef_OULD_DJABALLAH" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationsID", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f37565c-b4c9-4aea-9b12-18b751865874", "1624ce4f-be04-4b12-8639-cb211b36f282", "85bd5a54-e826-44b2-abbb-174fc4eb2f9b", "Developer", "Developer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7f37565c-b4c9-4aea-9b12-18b751865874", "1d78d3cc-9171-4513-b639-f3ea026988f9" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetApplications_ApplicationsName",
                table: "AspNetApplications",
                column: "ApplicationsName",
                unique: true,
                filter: "[ApplicationsName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetApplications_ShortName",
                table: "AspNetApplications",
                column: "ShortName",
                unique: true,
                filter: "[ShortName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetApplications_ApplicationsName",
                table: "AspNetApplications");

            migrationBuilder.DropIndex(
                name: "IX_AspNetApplications_ShortName",
                table: "AspNetApplications");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f37565c-b4c9-4aea-9b12-18b751865874", "1d78d3cc-9171-4513-b639-f3ea026988f9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f37565c-b4c9-4aea-9b12-18b751865874");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d78d3cc-9171-4513-b639-f3ea026988f9");

            migrationBuilder.DeleteData(
                table: "AspNetApplications",
                keyColumn: "ApplicationsID",
                keyValue: "1624ce4f-be04-4b12-8639-cb211b36f282");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "AspNetApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationsName",
                table: "AspNetApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetApplications",
                columns: new[] { "ApplicationsID", "ApplicationsName", "ShortName" },
                values: new object[] { "34863c7c-578a-43b4-a54d-8ab1b8c52e33", "Applications Centre", "AppCentre" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Grade", "LockoutEnabled", "LockoutEnd", "Matricule", "NN", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "Service", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd9ec744-4db0-4df7-afe5-ba0c5861cd51", 0, "f898f542-5cc3-4a7e-b3d4-b5aad55c66a0", "Youcef_OULD_DJABALLAH@AppCentre.DRH", true, 15, false, null, "3K174", 400123, "Youcef", "Youcef_OULD_DJABALLAH@AppCentre.DRH", null, "R9CwnWEjrWLxEXfeJOEe2srXIOZj5vqTXK1gUEL++oI=", null, false, "OULD DJABALLAH", "14d6e672-8bda-4524-b83f-dccb7028cec5", "16H\\", false, "Youcef_OULD_DJABALLAH" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationsID", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7504e4b1-0545-47e6-a43f-9a9415120630", "34863c7c-578a-43b4-a54d-8ab1b8c52e33", "0b56c731-6fd5-48b9-9e21-ef716ed1786a", "Developer", "Developer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7504e4b1-0545-47e6-a43f-9a9415120630", "cd9ec744-4db0-4df7-afe5-ba0c5861cd51" });
        }
    }
}
