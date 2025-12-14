using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sliders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TextAlignment",
                table: "Sliders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                table: "Sliders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePosition",
                table: "Sliders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ButtonUrl",
                table: "Sliders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ButtonText",
                table: "Sliders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColor",
                table: "Sliders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dimensions",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IconClass",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TextAlignment",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePosition",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ButtonUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ButtonText",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColor",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dimensions",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "IconClass",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2152), new DateTime(2024, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2208), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2238), new DateTime(2023, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2244), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2256), new DateTime(2022, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2263), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2273), new DateTime(2021, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2278), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2279) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2288), new DateTime(2020, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2294), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2296) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2305), new DateTime(2019, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2311), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "PublishDate", "SaleEndDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2352), new DateTime(2018, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2358), new DateTime(2026, 1, 9, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2369), new DateTime(2017, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2384), new DateTime(2016, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2401), new DateTime(2015, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2407) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2417), new DateTime(2014, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2431), new DateTime(2013, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2437) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2446), new DateTime(2012, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2495), new DateTime(2011, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2511), new DateTime(2010, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2527), new DateTime(2009, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2532) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2542), new DateTime(2008, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2547) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2557), new DateTime(2007, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2572), new DateTime(2006, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "PublishDate" },
                values: new object[] { new DateTime(2025, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2614), new DateTime(2005, 12, 10, 2, 5, 41, 496, DateTimeKind.Local).AddTicks(2620) });
        }
    }
}
