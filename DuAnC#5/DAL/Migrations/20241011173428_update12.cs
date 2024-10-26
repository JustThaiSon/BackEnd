using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class update12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AltText",
                table: "ProductImage");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ProductImage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProductImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("0bac5f75-4d31-479c-83c3-5d9c41d279e3"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 12, 0, 34, 27, 625, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 12, 0, 34, 27, 625, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("cbf30525-8058-406a-8a4f-67076449610d"), "America", "ThaiSon", new DateTime(2024, 10, 12, 0, 34, 27, 626, DateTimeKind.Local).AddTicks(110), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("4aa35dd1-3c47-4101-b00e-27fe33f1ad95"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 12, 0, 34, 27, 626, DateTimeKind.Local).AddTicks(168), "Nuốc ngọt không đường", new Guid("cbf30525-8058-406a-8a4f-67076449610d"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bac5f75-4d31-479c-83c3-5d9c41d279e3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4aa35dd1-3c47-4101-b00e-27fe33f1ad95"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("cbf30525-8058-406a-8a4f-67076449610d"));

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProductImage");

            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
