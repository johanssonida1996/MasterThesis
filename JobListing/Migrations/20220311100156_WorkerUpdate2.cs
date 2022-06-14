using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class WorkerUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Workers_WorkerId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTypes_Workers_WorkerId",
                table: "WorkTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTypes_WorkerId",
                table: "WorkTypes");

            migrationBuilder.DropIndex(
                name: "IX_Files_WorkerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileOneId",
                table: "Workers",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "WorkTypesId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighSchool = table.Column<bool>(type: "bit", nullable: false),
                    University = table.Column<bool>(type: "bit", nullable: false),
                    Polytechnic = table.Column<bool>(type: "bit", nullable: false),
                    Komvux = table.Column<bool>(type: "bit", nullable: false),
                    PeopleHighSchool = table.Column<bool>(type: "bit", nullable: false),
                    CourseOrElse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_EducationId",
                table: "Workers",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileOneId",
                table: "Workers",
                column: "FileOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileThreeId",
                table: "Workers",
                column: "FileThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_FileTwoId",
                table: "Workers",
                column: "FileTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Education_EducationId",
                table: "Workers",
                column: "EducationId",
                principalTable: "Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Files_FileOneId",
                table: "Workers",
                column: "FileOneId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId",
                principalTable: "WorkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Education_EducationId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileOneId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileThreeId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Files_FileTwoId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Workers_EducationId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileOneId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileThreeId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_FileTwoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileOneId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileThreeId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "FileTwoId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkTypesId",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "WorkTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypes_WorkerId",
                table: "WorkTypes",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_WorkerId",
                table: "Files",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Workers_WorkerId",
                table: "Files",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTypes_Workers_WorkerId",
                table: "WorkTypes",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
