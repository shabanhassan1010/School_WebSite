using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWebSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "students",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "departments",
                newName: "DNameAr");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNameEn",
                table: "departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DNameEn",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DNameAr",
                table: "departments",
                newName: "DName");
        }
    }
}
