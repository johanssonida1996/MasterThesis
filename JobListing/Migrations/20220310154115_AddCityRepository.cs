using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class AddCityRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { 1, "Stockholm" },
                    { 2, "Göteborg" },
                    { 3, "Malmö" },
                    { 4, "Örebro" },
                    { 5, "Västerrås" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CityId",
                table: "Workers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Cities_CityId",
                table: "Workers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Cities_CityId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CityId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
