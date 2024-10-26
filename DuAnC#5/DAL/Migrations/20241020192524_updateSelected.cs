using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateSelected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "selectedItem",
                table: "CartDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "selectedItem",
                table: "CartDetail");

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
    }
}
