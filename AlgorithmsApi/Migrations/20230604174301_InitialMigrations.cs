﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgorithmsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlgorithmSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    algorithmname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    usecases = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmSet", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmSet");
        }
    }
}
