using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("00d3a7b1-65a9-46a8-b086-a10c141c72d1"));

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("b7d07b8b-7177-4008-b9ca-197897846521"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b210dd90-2e0e-4d1d-ad16-63037a2f0a9c"), null, "Administrator role", "admin", "ADMIN" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b210dd90-2e0e-4d1d-ad16-63037a2f0a9c"));

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
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), null, "Administrator role", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 51, 51, 362, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d152ca1c-d519-40e2-bc1e-54688b7685ae"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 27, 0, 51, 51, 362, DateTimeKind.Local).AddTicks(7359));

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Country", "CreateBy", "CreatedDate", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("b7d07b8b-7177-4008-b9ca-197897846521"), "America", "ThaiSon", new DateTime(2024, 9, 27, 0, 51, 51, 362, DateTimeKind.Local).AddTicks(7673), "COCA", "", null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreateBy", "CreatedDate", "Description", "ManufactureId", "Name", "Price", "Quantity", "Status", "UpdateBy", "UpdateDate" },
                values: new object[] { new Guid("00d3a7b1-65a9-46a8-b086-a10c141c72d1"), new Guid("473d4d0b-6e80-423c-a73e-65db3c1fc127"), "ThaiSon", new DateTime(2024, 9, 27, 0, 51, 51, 362, DateTimeKind.Local).AddTicks(7721), "Nuốc ngọt không đường", new Guid("b7d07b8b-7177-4008-b9ca-197897846521"), "Nước ngọt CoCaCoLa", "100000", 50, 1, "", null });
        }
    }
}
