using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_field_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "Isbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Books",
                newName: "ISBN");
        }
    }
}
