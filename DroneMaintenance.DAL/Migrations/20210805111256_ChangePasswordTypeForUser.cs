using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneMaintenance.DAL.Migrations
{
    public partial class ChangePasswordTypeForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(44)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(88)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "4sLNhNFsQZl0q0JqGraIu6CxQXQfdGxCg2fpIymmBtg=", "CN4lu7moUkoFxn73xK7EEA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Jw2B38UvabRSqBkpX0T2wOrItHt/I7QkTsuMGApz7sQ=", "qoLvOfVLiKdwflEH1LoPwQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "User",
                type: "CHAR(44)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "CHAR(88)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
