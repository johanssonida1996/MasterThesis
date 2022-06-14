using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class Worktypemm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "WorkTypesWorker",
                columns: table => new
                {
                    WorkTypesId = table.Column<int>(type: "int", nullable: false),
                    WorkersWorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypesWorker", x => new { x.WorkTypesId, x.WorkersWorkerId });
                    table.ForeignKey(
                        name: "FK_WorkTypesWorker_Workers_WorkersWorkerId",
                        column: x => x.WorkersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTypesWorker_WorkTypes_WorkTypesId",
                        column: x => x.WorkTypesId,
                        principalTable: "WorkTypes",
                        principalColumn: "WorkTypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_WorkerId",
                table: "Files",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypesWorker_WorkersWorkerId",
                table: "WorkTypesWorker",
                column: "WorkersWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Workers_WorkerId",
                table: "Files",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Workers_WorkerId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "WorkTypesWorker");

            migrationBuilder.DropIndex(
                name: "IX_Files_WorkerId",
                table: "Files");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId",
                principalTable: "WorkTypes",
                principalColumn: "WorkTypesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
