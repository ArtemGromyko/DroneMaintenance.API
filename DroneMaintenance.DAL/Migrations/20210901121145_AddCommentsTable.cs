using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneMaintenance.DAL.Migrations
{
    public partial class AddCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Header", "Text", "UserId" },
                values: new object[] { new Guid("75518431-3035-4a5d-8f91-d8a6e8f8af47"), "Header1", "some text some text some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text", new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Header", "Text", "UserId" },
                values: new object[] { new Guid("601ec7d3-b5c9-43c8-8adb-63fdc67bb1bd"), "Header2", "some text some text some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text", new Guid("85d2dad8-5ad5-4ad7-ab42-2a883cf0846a") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Header", "Text", "UserId" },
                values: new object[] { new Guid("2e296f23-9a12-4991-ad3a-d5ea454d64db"), "Header3", "some text some text some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text some text  some text  some text  some text  some text  some text  some text  some text  some text  some text", new Guid("bf62c2cd-aa17-47ea-b575-f8d769966fb9") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
