using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.DAL.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicis_Rols_RolId",
                table: "Kullanicis");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicis_RolId",
                table: "Kullanicis");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Kullanicis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Kullanicis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.RolId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicis_RolId",
                table: "Kullanicis",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicis_Rols_RolId",
                table: "Kullanicis",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
