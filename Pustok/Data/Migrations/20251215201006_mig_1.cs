using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9468), new DateTime(2024, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9521), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9534) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9549), new DateTime(2023, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9555), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9566), new DateTime(2022, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9572), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9582), new DateTime(2021, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9588), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9597), new DateTime(2020, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9604), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9615), new DateTime(2019, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9621), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9622) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9630), new DateTime(2018, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9652), new DateTime(2026, 1, 15, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9663), new DateTime(2017, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9678), new DateTime(2016, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9695), new DateTime(2015, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9701) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9710), new DateTime(2014, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9725), new DateTime(2013, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9740), new DateTime(2012, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9793), new DateTime(2011, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9799) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9809), new DateTime(2010, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9824), new DateTime(2009, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9839), new DateTime(2008, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9855), new DateTime(2007, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9869), new DateTime(2006, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9883), new DateTime(2005, 12, 16, 0, 10, 5, 15, DateTimeKind.Local).AddTicks(9922) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(6967), new DateTime(2024, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7043), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7094), new DateTime(2023, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7106), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7127), new DateTime(2022, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7228), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7247), new DateTime(2021, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7256), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7274), new DateTime(2020, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7283), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7302), new DateTime(2019, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7310), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7329), new DateTime(2018, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7338), new DateTime(2026, 1, 13, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7355), new DateTime(2017, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7383), new DateTime(2016, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7462), new DateTime(2015, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7489), new DateTime(2014, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7510), new DateTime(2013, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7530), new DateTime(2012, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7537) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7550), new DateTime(2011, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7569), new DateTime(2010, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7588), new DateTime(2009, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7630) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7643), new DateTime(2008, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7650) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7664), new DateTime(2007, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7685), new DateTime(2006, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7705), new DateTime(2005, 12, 14, 20, 3, 14, 830, DateTimeKind.Local).AddTicks(7711) });
        }
    }
}
