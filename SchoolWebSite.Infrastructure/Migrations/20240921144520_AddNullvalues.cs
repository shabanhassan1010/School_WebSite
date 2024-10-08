﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWebSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNullvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "studentSubjects",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "studentSubjects");
        }
    }
}
