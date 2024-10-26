using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e5a1a5d7-5c6c-49ff-8564-883bc21a807f"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("dc6cabac-97e2-40a5-a5ad-0acd3eb2ce71"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 56, 19, 692, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 56, 19, 692, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("dc6cabac-97e2-40a5-a5ad-0acd3eb2ce71"), "America", "ThaiSon", new DateTime(2024, 9, 27, 0, 56, 19, 692, DateTimeKind.Local).AddTicks(5767), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("e5a1a5d7-5c6c-49ff-8564-883bc21a807f"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 27, 0, 56, 19, 692, DateTimeKind.Local).AddTicks(5852), "Nuốc ngọt không đường", new Guid("dc6cabac-97e2-40a5-a5ad-0acd3eb2ce71"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }
    }
}
