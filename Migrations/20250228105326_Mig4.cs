using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "ImagePath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Items");
        }
    }
}
