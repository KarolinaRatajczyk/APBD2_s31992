using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Poprawa_kol2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Training_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => new { x.Employee_ID, x.Training_ID });
                    table.ForeignKey(
                        name: "FK_Interests_Employees_Employee_ID",
                        column: x => x.Employee_ID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interests_Trainings_Training_ID",
                        column: x => x.Training_ID,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAttendances",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Training_ID = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAttendances", x => new { x.Employee_ID, x.Training_ID });
                    table.ForeignKey(
                        name: "FK_TrainingAttendances_Employees_Employee_ID",
                        column: x => x.Employee_ID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAttendances_Trainings_Training_ID",
                        column: x => x.Training_ID,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "John" },
                    { 2, "Finance", "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "ID", "Location", "Topic" },
                values: new object[,]
                {
                    { 1, "Washington", "Podstawy programowania" },
                    { 2, "Warsaw", "Bezpieczenstwo" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Employee_ID", "Training_ID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "TrainingAttendances",
                columns: new[] { "Employee_ID", "Training_ID", "AttendanceDate", "FeedbackScore" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 2, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_Training_ID",
                table: "Interests",
                column: "Training_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAttendances_Training_ID",
                table: "TrainingAttendances",
                column: "Training_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "TrainingAttendances");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
