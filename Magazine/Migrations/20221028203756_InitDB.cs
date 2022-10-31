using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagazineHead",
                columns: table => new
                {
                    MagazineHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SaleTagColor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ButtonColor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FontColor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Background = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineHead", x => x.MagazineHeadId);
                });

            migrationBuilder.CreateTable(
                name: "MagazinePayment",
                columns: table => new
                {
                    MagazinePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PaymentIcon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MagazineHeadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazinePayment", x => x.MagazinePaymentId);
                    table.ForeignKey(
                        name: "FK_MagazinePayment_MagazineHead_MagazineHeadId",
                        column: x => x.MagazineHeadId,
                        principalTable: "MagazineHead",
                        principalColumn: "MagazineHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagazineSection",
                columns: table => new
                {
                    MagazineSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Section_Banner = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Section_Display = table.Column<int>(type: "int", nullable: false),
                    MagazineHeadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineSection", x => x.MagazineSectionId);
                    table.ForeignKey(
                        name: "FK_MagazineSection_MagazineHead_MagazineHeadId",
                        column: x => x.MagazineHeadId,
                        principalTable: "MagazineHead",
                        principalColumn: "MagazineHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagazineSlider",
                columns: table => new
                {
                    MagazineSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MagazineHeadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineSlider", x => x.MagazineSliderId);
                    table.ForeignKey(
                        name: "FK_MagazineSlider_MagazineHead_MagazineHeadId",
                        column: x => x.MagazineHeadId,
                        principalTable: "MagazineHead",
                        principalColumn: "MagazineHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagazineItems",
                columns: table => new
                {
                    MagazineItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemSalesPrice = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ItemDiscountedPrice = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ItemDiscountPercentage = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ItemDiscountAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ItemMaximumOrderQty = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ItemDisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ItemDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MagazineHeadId = table.Column<int>(type: "int", nullable: false),
                    MagazineSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineItems", x => x.MagazineItemId);
                    table.ForeignKey(
                        name: "FK_MagazineItems_MagazineHead_MagazineHeadId",
                        column: x => x.MagazineHeadId,
                        principalTable: "MagazineHead",
                        principalColumn: "MagazineHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagazineItems_MagazineSection_MagazineSectionId",
                        column: x => x.MagazineSectionId,
                        principalTable: "MagazineSection",
                        principalColumn: "MagazineSectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MagazineItems_MagazineHeadId",
                table: "MagazineItems",
                column: "MagazineHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_MagazineItems_MagazineSectionId",
                table: "MagazineItems",
                column: "MagazineSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MagazinePayment_MagazineHeadId",
                table: "MagazinePayment",
                column: "MagazineHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_MagazineSection_MagazineHeadId",
                table: "MagazineSection",
                column: "MagazineHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_MagazineSlider_MagazineHeadId",
                table: "MagazineSlider",
                column: "MagazineHeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MagazineItems");

            migrationBuilder.DropTable(
                name: "MagazinePayment");

            migrationBuilder.DropTable(
                name: "MagazineSlider");

            migrationBuilder.DropTable(
                name: "MagazineSection");

            migrationBuilder.DropTable(
                name: "MagazineHead");
        }
    }
}
