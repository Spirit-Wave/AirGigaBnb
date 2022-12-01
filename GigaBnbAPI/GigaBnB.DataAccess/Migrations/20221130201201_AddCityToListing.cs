using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaBnB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCityToListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Listings");
        }
    }
}
