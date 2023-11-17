using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class deleteFeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "houses",
                newName: "house_price");

            migrationBuilder.RenameColumn(
                name: "nu_room",
                table: "houses",
                newName: "house_nu_room");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "apartments",
                newName: "apartment_price");

            migrationBuilder.RenameColumn(
                name: "nu_room",
                table: "apartments",
                newName: "apartment_nu_room");

            migrationBuilder.AlterColumn<string>(
                name: "pi_image",
                table: "property_image",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "apartment_state",
                table: "apartments",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apartment_state",
                table: "apartments");

            migrationBuilder.RenameColumn(
                name: "house_price",
                table: "houses",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "house_nu_room",
                table: "houses",
                newName: "nu_room");

            migrationBuilder.RenameColumn(
                name: "apartment_price",
                table: "apartments",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "apartment_nu_room",
                table: "apartments",
                newName: "nu_room");

            migrationBuilder.AlterColumn<string>(
                name: "pi_image",
                table: "property_image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
