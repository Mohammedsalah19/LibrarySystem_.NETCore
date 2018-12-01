using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryData.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibaryCard_LibaryCardId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryAssets_LibraryBranch_LocationId",
                table: "LibraryAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibaryCard_LibaryCardId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranch_LibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBranch",
                table: "LibraryBranch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibaryCard",
                table: "LibaryCard");

            migrationBuilder.RenameTable(
                name: "LibraryBranch",
                newName: "LibraryBranchs");

            migrationBuilder.RenameTable(
                name: "LibaryCard",
                newName: "LibaryCards");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "LibraryAssets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "LibraryAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeweyIndex",
                table: "LibraryAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "LibraryAssets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBranchs",
                table: "LibraryBranchs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibaryCards",
                table: "LibaryCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloseTime = table.Column<int>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    OpenTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckOutHistoies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckedIn = table.Column<DateTime>(nullable: true),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    LibraryAssetId = table.Column<int>(nullable: false),
                    LibraryCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutHistoies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOutHistoies_LibraryAssets_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOutHistoies_LibaryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibaryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoldPlaced = table.Column<DateTime>(nullable: false),
                    LibaryCardId = table.Column<int>(nullable: true),
                    LibraryAssetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_holds_LibaryCards_LibaryCardId",
                        column: x => x.LibaryCardId,
                        principalTable: "LibaryCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_holds_LibraryAssets_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Director = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutHistoies_LibraryAssetId",
                table: "CheckOutHistoies",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutHistoies_LibraryCardId",
                table: "CheckOutHistoies",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_holds_LibaryCardId",
                table: "holds",
                column: "LibaryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_holds_LibraryAssetId",
                table: "holds",
                column: "LibraryAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibaryCards_LibaryCardId",
                table: "Checkouts",
                column: "LibaryCardId",
                principalTable: "LibaryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryAssets_LibraryBranchs_LocationId",
                table: "LibraryAssets",
                column: "LocationId",
                principalTable: "LibraryBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibaryCards_LibaryCardId",
                table: "Patrons",
                column: "LibaryCardId",
                principalTable: "LibaryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranchs_LibraryBranchId",
                table: "Patrons",
                column: "LibraryBranchId",
                principalTable: "LibraryBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibaryCards_LibaryCardId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryAssets_LibraryBranchs_LocationId",
                table: "LibraryAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibaryCards_LibaryCardId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranchs_LibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckOutHistoies");

            migrationBuilder.DropTable(
                name: "holds");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBranchs",
                table: "LibraryBranchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibaryCards",
                table: "LibaryCards");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "LibraryAssets");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "LibraryAssets");

            migrationBuilder.DropColumn(
                name: "DeweyIndex",
                table: "LibraryAssets");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "LibraryAssets");

            migrationBuilder.RenameTable(
                name: "LibraryBranchs",
                newName: "LibraryBranch");

            migrationBuilder.RenameTable(
                name: "LibaryCards",
                newName: "LibaryCard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBranch",
                table: "LibraryBranch",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibaryCard",
                table: "LibaryCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibaryCard_LibaryCardId",
                table: "Checkouts",
                column: "LibaryCardId",
                principalTable: "LibaryCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryAssets_LibraryBranch_LocationId",
                table: "LibraryAssets",
                column: "LocationId",
                principalTable: "LibraryBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibaryCard_LibaryCardId",
                table: "Patrons",
                column: "LibaryCardId",
                principalTable: "LibaryCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranch_LibraryBranchId",
                table: "Patrons",
                column: "LibraryBranchId",
                principalTable: "LibraryBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
