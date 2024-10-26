using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("21d76ee1-0f16-4c7b-8b6b-b11378ed166c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f3c5053d-013b-4dfa-9971-2c6f3da9c31a"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("6a2dccb9-598c-4f5f-ab10-1e46feb6b8f8"));

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Order");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceSale",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("943eb710-02de-4e89-8df5-326a0f6a958b"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 1, 47, 55, 399, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 1, 47, 55, 399, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("09f59130-08be-44a2-b578-2bc03192ef80"), "America", "ThaiSon", new DateTime(2024, 10, 24, 1, 47, 55, 399, DateTimeKind.Local).AddTicks(1506), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("a896c993-059c-49ec-ae1a-1332a96b95dd"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 24, 1, 47, 55, 399, DateTimeKind.Local).AddTicks(1560), "Nuốc ngọt không đường", new Guid("09f59130-08be-44a2-b578-2bc03192ef80"), "Nước ngọt CoCaCoLa", 100000m, 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("943eb710-02de-4e89-8df5-326a0f6a958b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a896c993-059c-49ec-ae1a-1332a96b95dd"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("09f59130-08be-44a2-b578-2bc03192ef80"));

            migrationBuilder.DropColumn(
                name: "TotalPriceSale",
                table: "Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("21d76ee1-0f16-4c7b-8b6b-b11378ed166c"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 21, 2, 25, 23, 307, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 21, 2, 25, 23, 307, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("6a2dccb9-598c-4f5f-ab10-1e46feb6b8f8"), "America", "ThaiSon", new DateTime(2024, 10, 21, 2, 25, 23, 307, DateTimeKind.Local).AddTicks(971), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("f3c5053d-013b-4dfa-9971-2c6f3da9c31a"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 21, 2, 25, 23, 307, DateTimeKind.Local).AddTicks(1010), "Nuốc ngọt không đường", new Guid("6a2dccb9-598c-4f5f-ab10-1e46feb6b8f8"), "Nước ngọt CoCaCoLa", 100000m, 50, 1, "", null });
        }
    }
}
