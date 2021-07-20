using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneMaintenance.DAL.Migrations
{
    public partial class IdToContractSparePartAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractSpareParts",
                table: "ContractSpareParts");

            migrationBuilder.DeleteData(
                table: "ContractSpareParts",
                keyColumns: new[] { "ContractId", "SparePartId" },
                keyValues: new object[] { new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"), new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa") });

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ContractSpareParts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractSpareParts",
                table: "ContractSpareParts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ContractSpareParts",
                columns: new[] { "Id", "ContractId", "Quantity", "SparePartId" },
                values: new object[] { new Guid("9cb1b5b0-4c66-4893-887f-76a259cf26a6"), new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"), 2, new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa") });

            migrationBuilder.CreateIndex(
                name: "IX_ContractSpareParts_ContractId",
                table: "ContractSpareParts",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractSpareParts",
                table: "ContractSpareParts");

            migrationBuilder.DropIndex(
                name: "IX_ContractSpareParts_ContractId",
                table: "ContractSpareParts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContractSpareParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractSpareParts",
                table: "ContractSpareParts",
                columns: new[] { "ContractId", "SparePartId" });
        }
    }
}
