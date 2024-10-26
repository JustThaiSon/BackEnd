using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateorrderdetails2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("32a44ec1-b97f-4001-9033-0b1baae73705"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 23, 40, 55, 678, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 23, 40, 55, 678, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("b755b965-ed59-47ff-bcfa-54c69a09082f"), "America", "ThaiSon", new DateTime(2024, 10, 25, 23, 40, 55, 678, DateTimeKind.Local).AddTicks(2661), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("3508fae1-a0e0-4a3d-9e98-27c1903a00fd"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 25, 23, 40, 55, 678, DateTimeKind.Local).AddTicks(2735), "Nuốc ngọt không đường", new Guid("b755b965-ed59-47ff-bcfa-54c69a09082f"), "Nước ngọt CoCaCoLa", 100000m, 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("32a44ec1-b97f-4001-9033-0b1baae73705"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3508fae1-a0e0-4a3d-9e98-27c1903a00fd"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("b755b965-ed59-47ff-bcfa-54c69a09082f"));

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Order");

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
    }
}
