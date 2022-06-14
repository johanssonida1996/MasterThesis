using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class UpdateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkTypes",
                newName: "WorkTypesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Educations",
                newName: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkTypesId",
                table: "WorkTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "Educations",
                newName: "Id");
        }
    }
}
