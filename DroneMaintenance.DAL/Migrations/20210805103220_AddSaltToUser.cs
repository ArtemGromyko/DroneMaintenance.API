using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneMaintenance.DAL.Migrations
{
    public partial class AddSaltToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Password",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "CHAR(88)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                type: "CHAR(44)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "821cxGjj1aXrLesJ+/K00e4AioL3S7szr15oAudTcew=", "yXXjzf8L/Ebz2rc65OZiWQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1+MrFH2zwmsdMVkOPU1ThxtYDk+zfcBrnhE8MY4gsKQ=", "7e3P7vLA2hp0pnjKUMJ7Mg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"));

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(88)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Password",
                table: "User",
                column: "Password");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[] { new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"), "donald@email.com", "Donald", "user", new Guid("f6736344-8a7e-43f4-9a1a-facf460b5f3f") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[] { new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a"), "sam@email.com", "Sam", "admin", new Guid("865ce3fc-de0d-4372-901d-05e0ba2b8d02") });
        }
    }
}
