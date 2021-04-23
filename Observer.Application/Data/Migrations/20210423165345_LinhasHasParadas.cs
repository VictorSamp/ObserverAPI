using Microsoft.EntityFrameworkCore.Migrations;

namespace ObserverAPI.Data.Migrations
{
    public partial class LinhasHasParadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_Linhas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Paradas");

            migrationBuilder.CreateTable(
                name: "LinhaParada",
                columns: table => new
                {
                    LinhasId = table.Column<long>(type: "bigint", nullable: false),
                    ParadasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaParada", x => new { x.LinhasId, x.ParadasId });
                    table.ForeignKey(
                        name: "FK_LinhaParada_Linhas_LinhasId",
                        column: x => x.LinhasId,
                        principalTable: "Linhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinhaParada_Paradas_ParadasId",
                        column: x => x.ParadasId,
                        principalTable: "Paradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinhaParada_ParadasId",
                table: "LinhaParada",
                column: "ParadasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinhaParada");

            migrationBuilder.AddColumn<long>(
                name: "LinhaId",
                table: "Paradas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_LinhaId",
                table: "Paradas",
                column: "LinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paradas_Linhas_LinhaId",
                table: "Paradas",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}