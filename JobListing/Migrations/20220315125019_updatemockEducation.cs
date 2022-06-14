using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class updatemockEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "IsSelected", "Name" },
                values: new object[,]
                {
                    { 11, false, "Gymnasieutbildning" },
                    { 12, false, "Universitets- och Högskoleutbildning" },
                    { 13, false, "Yrkeshögskoleutbildning" },
                    { 14, false, "Komvux / Vuxenutbildning" },
                    { 15, false, "Folkhögskoleutbildning" },
                    { 16, false, "Kurs eller övrig utbildning" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "IsSelected", "Name" },
                values: new object[,]
                {
                    { 1, false, "Gymnasieutbildning" },
                    { 2, false, "Universitets- och Högskoleutbildning" },
                    { 3, false, "Yrkeshögskoleutbildning" },
                    { 4, false, "Komvux / Vuxenutbildning" },
                    { 5, false, "Folkhögskoleutbildning" },
                    { 6, false, "Kurs eller övrig utbildning" }
                });
        }
    }
}
