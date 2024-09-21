using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWebSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigrationToAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManger",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InsManger",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManger",
                table: "departments",
                column: "InsManger",
                unique: true,
                filter: "[InsManger] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManger",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsManger",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManger",
                table: "departments",
                column: "InsManger",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
