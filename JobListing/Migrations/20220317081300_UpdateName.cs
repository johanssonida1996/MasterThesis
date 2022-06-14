using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class UpdateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WorkTypes",
                newName: "WorkTypesName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Educations",
                newName: "EducationName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkTypesName",
                table: "WorkTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EducationName",
                table: "Educations",
                newName: "Name");
        }
    }
}
