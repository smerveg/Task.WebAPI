using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createUrunSiparis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisUrun");

            migrationBuilder.AlterColumn<int>(
                name: "Adet",
                table: "UrunSiparis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Adet",
                table: "UrunSiparis",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SiparisUrun",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    UrunsUrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisUrun", x => new { x.SiparisId, x.UrunsUrunId });
                    table.ForeignKey(
                        name: "FK_SiparisUrun_Siparis_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisUrun_Uruns_UrunsUrunId",
                        column: x => x.UrunsUrunId,
                        principalTable: "Uruns",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrun_UrunsUrunId",
                table: "SiparisUrun",
                column: "UrunsUrunId");
        }
    }
}
