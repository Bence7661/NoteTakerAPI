using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteTakerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedNoteAndNotebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notebook",
                columns: new[] { "Id", "Color", "Name", "UserId" },
                values: new object[] { 1, 3, "TestNotebook", 1 });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Body", "NotebookId", "Title" },
                values: new object[] { 1, "Test note body.", 1, "Test note title" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notebook",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
