using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWebSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "DNameEn",
                table: "departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "DNameEn",
                table: "departments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");
        }
    }
}
