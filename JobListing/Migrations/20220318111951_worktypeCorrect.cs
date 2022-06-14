using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class worktypeCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTypesWorker_Workers_WorkersWorkerId",
                table: "WorkTypesWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTypesWorker",
                table: "WorkTypesWorker");

            migrationBuilder.RenameColumn(
                name: "WorkersWorkerId",
                table: "WorkTypesWorker",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTypesWorker_WorkersWorkerId",
                table: "WorkTypesWorker",
                newName: "IX_WorkTypesWorker_WorkerId");

            migrationBuilder.AddColumn<int>(
                name: "WorkTypesWorkerId",
                table: "WorkTypesWorker",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<int>(
            //    name: "WorkTypesId",
            //    table: "Workers",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTypesWorker",
                table: "WorkTypesWorker",
                column: "WorkTypesWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypesWorker_WorkTypesId",
                table: "WorkTypesWorker",
                column: "WorkTypesId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Workers_WorkTypesId",
            //    table: "Workers",
            //    column: "WorkTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId",
                principalTable: "WorkTypes",
                principalColumn: "WorkTypesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTypesWorker_Workers_WorkerId",
                table: "WorkTypesWorker",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTypesWorker_Workers_WorkerId",
                table: "WorkTypesWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTypesWorker",
                table: "WorkTypesWorker");

            migrationBuilder.DropIndex(
                name: "IX_WorkTypesWorker_WorkTypesId",
                table: "WorkTypesWorker");

            //migrationBuilder.DropIndex(
            //    name: "IX_Workers_WorkTypesId",
            //    table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkTypesWorkerId",
                table: "WorkTypesWorker");

            //migrationBuilder.DropColumn(
            //    name: "WorkTypesId",
            //    table: "Workers");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "WorkTypesWorker",
                newName: "WorkersWorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTypesWorker_WorkerId",
                table: "WorkTypesWorker",
                newName: "IX_WorkTypesWorker_WorkersWorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTypesWorker",
                table: "WorkTypesWorker",
                columns: new[] { "WorkTypesId", "WorkersWorkerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTypesWorker_Workers_WorkersWorkerId",
                table: "WorkTypesWorker",
                column: "WorkersWorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
