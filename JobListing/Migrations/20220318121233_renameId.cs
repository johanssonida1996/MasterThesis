using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class renameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkTypesId",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "WorkTypesWorkerId",
                table: "WorkTypesWorker",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkTypesId",
                table: "WorkTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Workers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkTypesWorker",
                newName: "WorkTypesWorkerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkTypes",
                newName: "WorkTypesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Workers",
                newName: "WorkerId");

            migrationBuilder.AddColumn<int>(
                name: "WorkTypesId",
                table: "Workers",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
