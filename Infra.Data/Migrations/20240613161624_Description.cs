using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: "");

            migrationBuilder.RenameColumn(
                name: "SubName",
                table: "TodoTasks",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "Code", "CreateAt", "Description", "IsComplete", "Name", "PercentageCompleted" },
                values: new object[] { "orqGEQkjZ4LVcmxxXLvKrXkKNrTNW24rzH", "1RSjwX", new DateTime(2024, 6, 13, 16, 16, 24, 282, DateTimeKind.Utc).AddTicks(2791), "", false, "Task Test", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: "orqGEQkjZ4LVcmxxXLvKrXkKNrTNW24rzH");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoTasks",
                newName: "SubName");

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "Code", "CreateAt", "IsComplete", "Name", "PercentageCompleted", "SubName" },
                values: new object[] { "", "82SdPz", new DateTime(2024, 6, 13, 11, 6, 49, 89, DateTimeKind.Utc).AddTicks(5561), false, "Task Test", 0, "" });
        }
    }
}
