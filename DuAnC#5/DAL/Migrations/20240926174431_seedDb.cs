using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("67b4bb45-5700-458c-96ae-9b8d9c1928b9"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("2d81baee-2d7a-4586-b113-4feda498b191"));

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 44, 30, 415, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 44, 30, 415, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("932bf10e-78f1-4aee-9cd0-04e5019f8432"), "America", "ThaiSon", new DateTime(2024, 9, 27, 0, 44, 30, 415, DateTimeKind.Local).AddTicks(5343), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("92120ff2-1fd3-4f71-814c-409dacc347a0"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 27, 0, 44, 30, 415, DateTimeKind.Local).AddTicks(5375), "Nuốc ngọt không đường", new Guid("932bf10e-78f1-4aee-9cd0-04e5019f8432"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("92120ff2-1fd3-4f71-814c-409dacc347a0"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("932bf10e-78f1-4aee-9cd0-04e5019f8432"));

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 42, 7, 379, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 42, 7, 379, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("2d81baee-2d7a-4586-b113-4feda498b191"), "America", "ThaiSon", new DateTime(2024, 9, 27, 0, 42, 7, 379, DateTimeKind.Local).AddTicks(9124), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("67b4bb45-5700-458c-96ae-9b8d9c1928b9"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 27, 0, 42, 7, 379, DateTimeKind.Local).AddTicks(9168), "Nuốc ngọt không đường", new Guid("2d81baee-2d7a-4586-b113-4feda498b191"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }
    }
}
