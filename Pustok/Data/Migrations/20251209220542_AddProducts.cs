using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pustok.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    SaleEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IconClass", "IsActive", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(1988), null, null, true, "Arts & Photography", null },
                    { 2, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2000), null, null, true, "Biographies", null },
                    { 3, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2002), null, null, true, "Business & Money", null },
                    { 4, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2003), null, null, true, "Children's Books", null },
                    { 5, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2033), null, null, true, "Comics", null },
                    { 6, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2035), null, null, true, "Cookbooks", null },
                    { 7, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2036), null, null, true, "Education", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedDate", "Description", "Dimensions", "DiscountPercentage", "HoverImagePath", "ISBN", "IsActive", "IsFeatured", "IsNew", "IsOnSale", "Language", "MainImagePath", "Name", "OldPrice", "PageCount", "Price", "PublishDate", "Publisher", "Rating", "ReviewCount", "SKU", "SaleEndDate", "SalesCount", "StockQuantity", "ViewCount", "Weight" },
                values: new object[,]
                {
                    { 1, "Author 1", 2, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2152), "This is a great book about topic 1. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 21, "product-3.jpg", "978-1-1001-101-1", true, true, false, true, "English", "product-2.jpg", "Book Title 1", 57m, 210, 35m, new DateTime(2024, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2208), "Publisher 1", 4.1m, 5, "BK1001", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2223), 2, 51, 10, 0.6m },
                    { 2, "Author 2", 3, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2238), "This is a great book about topic 2. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 22, "product-4.jpg", "978-2-1002-102-2", true, true, false, true, "English", "product-3.jpg", "Book Title 2", 64m, 220, 40m, new DateTime(2023, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2244), "Publisher 2", 4.2m, 10, "BK1002", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2247), 4, 52, 20, 0.7m },
                    { 3, "Author 3", 4, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2256), "This is a great book about topic 3. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 23, "product-5.jpg", "978-3-1003-103-3", true, true, true, true, "English", "product-4.jpg", "Book Title 3", 71m, 230, 45m, new DateTime(2022, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2263), "Publisher 3", 4.3m, 15, "BK1003", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2264), 6, 53, 30, 0.8m },
                    { 4, "Author 4", 5, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2273), "This is a great book about topic 4. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 24, "product-6.jpg", "978-4-1004-104-4", true, true, false, true, "English", "product-5.jpg", "Book Title 4", 78m, 240, 50m, new DateTime(2021, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2278), "Publisher 4", 4.4m, 20, "BK1004", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2279), 8, 54, 40, 0.9m },
                    { 5, "Author 5", 6, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2288), "This is a great book about topic 5. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 20, "product-7.jpg", "978-5-1005-105-5", true, true, false, true, "English", "product-6.jpg", "Book Title 5", 85m, 250, 55m, new DateTime(2020, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2294), "Publisher 5", 4.5m, 25, "BK1005", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2296), 10, 55, 50, 1.0m },
                    { 6, "Author 6", 7, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2305), "This is a great book about topic 6. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 21, "product-8.jpg", "978-6-1006-106-6", true, true, true, true, "English", "product-7.jpg", "Book Title 6", 92m, 260, 60m, new DateTime(2019, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2311), "Publisher 6", 4.6m, 30, "BK1006", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2312), 12, 56, 60, 1.1m },
                    { 7, "Author 7", 1, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2352), "This is a great book about topic 7. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 22, "product-9.jpg", "978-7-1007-107-7", true, true, false, true, "English", "product-8.jpg", "Book Title 7", 99m, 270, 65m, new DateTime(2018, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2358), "Publisher 7", 4.7m, 35, "BK1007", new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2360), 14, 57, 70, 1.2m },
                    { 8, "Author 8", 2, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2369), "This is a great book about topic 8. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 23, "product-10.jpg", "978-8-1008-108-8", true, true, false, false, "English", "product-9.jpg", "Book Title 8", 106m, 280, 70m, new DateTime(2017, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2375), "Publisher 8", 4.8m, 40, "BK1008", null, 16, 58, 80, 1.3m },
                    { 9, "Author 9", 3, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2384), "This is a great book about topic 9. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 24, "product-11.jpg", "978-9-1009-109-9", true, true, true, false, "English", "product-10.jpg", "Book Title 9", 113m, 290, 75m, new DateTime(2016, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2390), "Publisher 9", 4.9m, 45, "BK1009", null, 18, 59, 90, 1.4m },
                    { 10, "Author 10", 4, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2401), "This is a great book about topic 10. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 20, "product-12.jpg", "978-10-1010-110-10", true, true, false, false, "English", "product-11.jpg", "Book Title 10", 120m, 300, 80m, new DateTime(2015, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2407), "Publisher 10", 4.0m, 50, "BK1010", null, 20, 60, 100, 1.5m },
                    { 11, "Author 11", 5, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2417), "This is a great book about topic 11. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 21, "product-13.jpg", "978-11-1011-111-11", true, true, false, false, "English", "product-12.jpg", "Book Title 11", 127m, 310, 85m, new DateTime(2014, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2422), "Publisher 11", 4.1m, 55, "BK1011", null, 22, 61, 110, 1.6m },
                    { 12, "Author 12", 6, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2431), "This is a great book about topic 12. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 22, "product-1.jpg", "978-12-1012-112-12", true, true, true, false, "English", "product-13.jpg", "Book Title 12", 134m, 320, 90m, new DateTime(2013, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2437), "Publisher 12", 4.2m, 60, "BK1012", null, 24, 62, 120, 1.7m },
                    { 13, "Author 13", 7, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2446), "This is a great book about topic 13. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 23, "product-2.jpg", "978-13-1013-113-13", true, false, false, false, "English", "product-1.jpg", "Book Title 13", 141m, 330, 95m, new DateTime(2012, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2485), "Publisher 13", 4.3m, 65, "BK1013", null, 26, 63, 130, 1.8m },
                    { 14, "Author 14", 1, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2495), "This is a great book about topic 14. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 24, "product-3.jpg", "978-14-1014-114-14", true, false, false, false, "English", "product-2.jpg", "Book Title 14", 148m, 340, 100m, new DateTime(2011, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2502), "Publisher 14", 4.4m, 70, "BK1014", null, 28, 64, 140, 1.9m },
                    { 15, "Author 15", 2, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2511), "This is a great book about topic 15. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 20, "product-4.jpg", "978-15-1015-115-15", true, false, true, false, "English", "product-3.jpg", "Book Title 15", 155m, 350, 105m, new DateTime(2010, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2517), "Publisher 15", 4.5m, 75, "BK1015", null, 30, 65, 150, 2.0m },
                    { 16, "Author 16", 3, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2527), "This is a great book about topic 16. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 21, "product-5.jpg", "978-16-1016-116-16", true, false, false, false, "English", "product-4.jpg", "Book Title 16", 162m, 360, 110m, new DateTime(2009, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2532), "Publisher 16", 4.6m, 80, "BK1016", null, 32, 66, 160, 2.1m },
                    { 17, "Author 17", 4, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2542), "This is a great book about topic 17. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 22, "product-6.jpg", "978-17-1017-117-17", true, false, false, false, "English", "product-5.jpg", "Book Title 17", 169m, 370, 115m, new DateTime(2008, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2547), "Publisher 17", 4.7m, 85, "BK1017", null, 34, 67, 170, 2.2m },
                    { 18, "Author 18", 5, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2557), "This is a great book about topic 18. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 23, "product-7.jpg", "978-18-1018-118-18", true, false, true, false, "English", "product-6.jpg", "Book Title 18", 176m, 380, 120m, new DateTime(2007, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2563), "Publisher 18", 4.8m, 90, "BK1018", null, 36, 68, 180, 2.3m },
                    { 19, "Author 19", 6, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2572), "This is a great book about topic 19. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 24, "product-8.jpg", "978-19-1019-119-19", true, false, false, false, "English", "product-7.jpg", "Book Title 19", 183m, 390, 125m, new DateTime(2006, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2577), "Publisher 19", 4.9m, 95, "BK1019", null, 38, 69, 190, 2.4m },
                    { 20, "Author 20", 7, new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2614), "This is a great book about topic 20. Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", "8.5 x 0.5 x 11 inches", 20, "product-9.jpg", "978-20-1020-120-20", true, false, false, false, "English", "product-8.jpg", "Book Title 20", 190m, 400, 130m, new DateTime(2005, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2620), "Publisher 20", 4.0m, 100, "BK1020", null, 40, 70, 200, 2.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
