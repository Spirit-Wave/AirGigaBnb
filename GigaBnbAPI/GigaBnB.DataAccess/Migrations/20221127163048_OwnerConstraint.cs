using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaBnB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OwnerConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Users_OwnerId",
                table: "Listings",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Users_OwnerId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings");
        }
    }
}
