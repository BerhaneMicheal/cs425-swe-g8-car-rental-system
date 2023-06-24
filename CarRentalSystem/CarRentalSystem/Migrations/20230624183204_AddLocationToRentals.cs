using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.Migrations
{
    public partial class AddLocationToRentals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickupLocationId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_PickupLocationId",
                table: "Rentals",
                column: "PickupLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ReservationId",
                table: "Rentals",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_PickupLocations_PickupLocationId",
                table: "Rentals",
                column: "PickupLocationId",
                principalTable: "PickupLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Reservations_ReservationId",
                table: "Rentals",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_PickupLocations_PickupLocationId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Reservations_ReservationId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_PickupLocationId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_ReservationId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "PickupLocationId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Rentals");
        }
    }
}
