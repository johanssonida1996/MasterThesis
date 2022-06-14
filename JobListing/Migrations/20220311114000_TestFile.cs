using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class TestFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileOneId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileOneId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileOneId",
                table: "Workers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileOne",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileOne",
                table: "Workers");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageUrl",
                table: "Workers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileOneId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileOneId",
                table: "Workers",
                column: "FileOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Files_FileOneId",
                table: "Workers",
                column: "FileOneId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
