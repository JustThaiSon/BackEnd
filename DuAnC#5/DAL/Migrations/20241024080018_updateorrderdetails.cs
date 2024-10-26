using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateorrderdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Status",
                table: "OrderDetails");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b1ebd5d7-4399-4d73-8a0c-166c7bc8e35b"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 15, 0, 17, 31, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 24, 15, 0, 17, 31, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("c3f5bf46-cef1-4ca0-8274-075d7395e087"), "America", "ThaiSon", new DateTime(2024, 10, 24, 15, 0, 17, 31, DateTimeKind.Local).AddTicks(6247), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("237ba754-77f3-4d26-9fb3-b2cf7f1a0131"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 24, 15, 0, 17, 31, DateTimeKind.Local).AddTicks(6475), "Nuốc ngọt không đường", new Guid("c3f5bf46-cef1-4ca0-8274-075d7395e087"), "Nước ngọt CoCaCoLa", 100000m, 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1ebd5d7-4399-4d73-8a0c-166c7bc8e35b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("237ba754-77f3-4d26-9fb3-b2cf7f1a0131"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("c3f5bf46-cef1-4ca0-8274-075d7395e087"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
