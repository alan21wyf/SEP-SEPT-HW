using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yifan_Wu.CabApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabTypes",
                columns: table => new
                {
                    CabTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabTypeName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabTypes", x => x.CabTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    FromPlace = table.Column<int>(type: "int", nullable: true),
                    ToPlace = table.Column<int>(type: "int", nullable: true),
                    PickupAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickupTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_FromPlace",
                        column: x => x.FromPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_ToPlace",
                        column: x => x.ToPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    FromPlace = table.Column<int>(type: "int", nullable: true),
                    ToPlace = table.Column<int>(type: "int", nullable: true),
                    PickupAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickupTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Comp_time = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    Charge = table.Column<decimal>(type: "Money", nullable: true),
                    Feedback = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings history_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings history_Places_FromPlace",
                        column: x => x.FromPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings history_Places_ToPlace",
                        column: x => x.ToPlace,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabTypeId",
                table: "Bookings",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FromPlace",
                table: "Bookings",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToPlace",
                table: "Bookings",
                column: "ToPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_CabTypeId",
                table: "Bookings history",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_FromPlace",
                table: "Bookings history",
                column: "FromPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings history_ToPlace",
                table: "Bookings history",
                column: "ToPlace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Bookings history");

            migrationBuilder.DropTable(
                name: "CabTypes");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
