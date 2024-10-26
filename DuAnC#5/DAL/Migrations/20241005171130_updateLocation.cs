using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("311de53a-3850-4e9c-80f8-ee6b0838eba7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("9a511d9a-00ce-461b-b500-8c8f2fb3a785"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("89990413-5c84-45d3-9c74-057a976434ed"));

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "Address",
                newName: "WardName");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Address",
                newName: "WardId");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "ProvinceName");

            migrationBuilder.AddColumn<string>(
                name: "DistrictId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("165454d1-d531-460d-b0f0-2e7b5c93b6cc"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 6, 0, 11, 30, 53, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 6, 0, 11, 30, 53, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("8c1a262b-33a6-4bc9-8545-2e58ad6e1c86"), "America", "ThaiSon", new DateTime(2024, 10, 6, 0, 11, 30, 53, DateTimeKind.Local).AddTicks(9413), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("384d2cb8-d495-48c3-8e82-c4383c6f7b72"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 6, 0, 11, 30, 53, DateTimeKind.Local).AddTicks(9447), "Nuốc ngọt không đường", new Guid("8c1a262b-33a6-4bc9-8545-2e58ad6e1c86"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("165454d1-d531-460d-b0f0-2e7b5c93b6cc"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("384d2cb8-d495-48c3-8e82-c4383c6f7b72"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("8c1a262b-33a6-4bc9-8545-2e58ad6e1c86"));

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "WardName",
                table: "Address",
                newName: "Ward");

            migrationBuilder.RenameColumn(
                name: "WardId",
                table: "Address",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "Address",
                newName: "City");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("311de53a-3850-4e9c-80f8-ee6b0838eba7"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 29, 13, 18, 56, 617, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 29, 13, 18, 56, 617, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("89990413-5c84-45d3-9c74-057a976434ed"), "America", "ThaiSon", new DateTime(2024, 9, 29, 13, 18, 56, 617, DateTimeKind.Local).AddTicks(9017), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("9a511d9a-00ce-461b-b500-8c8f2fb3a785"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 29, 13, 18, 56, 617, DateTimeKind.Local).AddTicks(9044), "Nuốc ngọt không đường", new Guid("89990413-5c84-45d3-9c74-057a976434ed"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }
    }
}
