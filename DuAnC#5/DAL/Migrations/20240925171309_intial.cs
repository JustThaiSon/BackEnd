using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreateBy", "CreatedDate", "Description", "Name", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 26, 0, 13, 8, 412, DateTimeKind.Local).AddTicks(3188), "Nước uống có ga", "COCA", 0, "", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateBy", "CreatedDate", "Description", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"), "ThaiSon", new DateTime(2024, 9, 26, 0, 13, 8, 412, DateTimeKind.Local).AddTicks(2986), "Nước uống", "Nước", "", null });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("a4c84aa5-4d37-4b31-a0bc-583b35532f57"), "America", "ThaiSon", new DateTime(2024, 9, 26, 0, 13, 8, 412, DateTimeKind.Local).AddTicks(3286), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("b1fa32af-615e-413a-bc3a-0a08f5563149"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 26, 0, 13, 8, 412, DateTimeKind.Local).AddTicks(3317), "Nuốc ngọt không đường", new Guid("a4c84aa5-4d37-4b31-a0bc-583b35532f57"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });

            migrationBuilder.InsertData(
                table: "Category_Product",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"), new Guid("b1fa32af-615e-413a-bc3a-0a08f5563149") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category_Product",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"), new Guid("b1fa32af-615e-413a-bc3a-0a08f5563149") });

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b1fa32af-615e-413a-bc3a-0a08f5563149"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("a4c84aa5-4d37-4b31-a0bc-583b35532f57"));
        }
    }
}
