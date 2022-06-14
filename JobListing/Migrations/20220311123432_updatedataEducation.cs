using Microsoft.EntityFrameworkCore.Migrations;

namespace JobListing.Migrations
{
    public partial class updatedataEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Education_EducationId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_EducationId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkTypesId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "FullTime",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "Internship",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "PartTime",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "CourseOrElse",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "HighSchool",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Komvux",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "PeopleHighSchool",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Polytechnic",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameColumn(
                name: "ProjectTime",
                table: "WorkTypes",
                newName: "IsSelected");

            migrationBuilder.RenameColumn(
                name: "University",
                table: "Educations",
                newName: "IsSelected");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTypesId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EducationId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "IsSelected", "Name" },
                values: new object[,]
                {
                    { 1, false, "Heltid" },
                    { 2, false, "Deltid" },
                    { 3, false, "Visstid/Projekt" },
                    { 4, false, "Praktik" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

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

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Educations");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameColumn(
                name: "IsSelected",
                table: "WorkTypes",
                newName: "ProjectTime");

            migrationBuilder.RenameColumn(
                name: "IsSelected",
                table: "Education",
                newName: "University");

            migrationBuilder.AddColumn<bool>(
                name: "FullTime",
                table: "WorkTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internship",
                table: "WorkTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PartTime",
                table: "WorkTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTypesId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EducationId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "CourseOrElse",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HighSchool",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Komvux",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PeopleHighSchool",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Polytechnic",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_EducationId",
                table: "Workers",
                column: "EducationId");

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
                name: "FK_Workers_WorkTypes_WorkTypesId",
                table: "Workers",
                column: "WorkTypesId",
                principalTable: "WorkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
