using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateSiparis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adet",
                table: "Siparis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "Siparis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
