using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class updateFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileThreeId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileTwoId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileThreeId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileTwoId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileThreeId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileTwoId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "FileThree",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileTwo",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileThree",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileTwo",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "FileThreeId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileTwoId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UntrustedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileThreeId",
                table: "Workers",
                column: "FileThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileTwoId",
                table: "Workers",
                column: "FileTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Files_FileThreeId",
                table: "Workers",
                column: "FileThreeId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Files_FileTwoId",
                table: "Workers",
                column: "FileTwoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
