using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevisaoProjetoNoticias.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageFieldNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");
        }
    }
}
