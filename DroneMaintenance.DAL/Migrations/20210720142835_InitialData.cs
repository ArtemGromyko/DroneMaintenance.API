using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneMaintenance.DAL.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkStart",
                table: "Contracts",
                newName: "WorkStartDate");

            migrationBuilder.RenameColumn(
                name: "WorkEnd",
                table: "Contracts",
                newName: "WorkEndDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cc38316e-ea63-473b-84fa-1efa00f3b6ce"), "Tom" },
                    { new Guid("5bf2d2e5-25c7-47d4-b5a0-13068ce73ab2"), "John" }
                });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "Id", "Manufacturer", "Model" },
                values: new object[,]
                {
                    { new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4"), "Xiaomi", "Mi Drone Mini" },
                    { new Guid("4e02aef0-98d7-430f-bd56-749992687066"), "DJI", "DJI Mini 2" }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa"), "sensor", 300m });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "ClientId", "Description", "DroneId", "RequestStatus", "ServiceType" },
                values: new object[] { new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56"), new Guid("cc38316e-ea63-473b-84fa-1efa00f3b6ce"), "description", new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4"), 0, 2 });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "ClientId", "Description", "DroneId", "RequestStatus", "ServiceType" },
                values: new object[] { new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af"), new Guid("5bf2d2e5-25c7-47d4-b5a0-13068ce73ab2"), null, new Guid("4e02aef0-98d7-430f-bd56-749992687066"), 0, 0 });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ServiceRequestId", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new Guid("85d636bf-637b-4ab3-9d83-894e829df3d6"), new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ServiceRequestId", "WorkEndDate", "WorkStartDate" },
                values: new object[] { new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"), new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ContractSpareParts",
                columns: new[] { "ContractId", "SparePartId", "Quantity" },
                values: new object[] { new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"), new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa"), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractSpareParts",
                keyColumns: new[] { "ContractId", "SparePartId" },
                keyValues: new object[] { new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"), new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa") });

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("85d636bf-637b-4ab3-9d83-894e829df3d6"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("50cb65ad-86a1-4abb-afca-fd4b867d7560"));

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: new Guid("38a5dc95-3ff1-4c8f-8041-872a65b41d56"));

            migrationBuilder.DeleteData(
                table: "SpareParts",
                keyColumn: "Id",
                keyValue: new Guid("193906c8-17a6-4a3c-8eb1-c540cdd6e3fa"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("cc38316e-ea63-473b-84fa-1efa00f3b6ce"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "Id",
                keyValue: new Guid("9fffa88b-91c5-42a6-8692-1fd8701fb0e4"));

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: new Guid("fb35b9ce-61c0-4ce3-a309-e742582845af"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("5bf2d2e5-25c7-47d4-b5a0-13068ce73ab2"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "Id",
                keyValue: new Guid("4e02aef0-98d7-430f-bd56-749992687066"));

            migrationBuilder.RenameColumn(
                name: "WorkStartDate",
                table: "Contracts",
                newName: "WorkStart");

            migrationBuilder.RenameColumn(
                name: "WorkEndDate",
                table: "Contracts",
                newName: "WorkEnd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
