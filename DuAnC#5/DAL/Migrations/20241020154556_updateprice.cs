using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("142f313f-41d7-4bc1-abfc-06adcdd636db"), null, "Employee role", "Employee", "Employee" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 22, 45, 55, 568, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 22, 45, 55, 568, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("7dbbe905-9926-42ef-9727-7a0b7bd9f1b4"), "America", "ThaiSon", new DateTime(2024, 10, 20, 22, 45, 55, 568, DateTimeKind.Local).AddTicks(3667), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("c245ab2a-ba9b-4250-b25f-bc4121320bf1"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 10, 20, 22, 45, 55, 568, DateTimeKind.Local).AddTicks(3711), "Nuốc ngọt không đường", new Guid("7dbbe905-9926-42ef-9727-7a0b7bd9f1b4"), "Nước ngọt CoCaCoLa", 100000m, 50, 1, "", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("142f313f-41d7-4bc1-abfc-06adcdd636db"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c245ab2a-ba9b-4250-b25f-bc4121320bf1"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("7dbbe905-9926-42ef-9727-7a0b7bd9f1b4"));

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
