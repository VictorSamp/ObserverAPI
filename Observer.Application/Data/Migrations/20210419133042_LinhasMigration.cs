using Microsoft.EntityFrameworkCore.Migrations;

namespace ObserverAPI.Data.Migrations
{
    public partial class LinhasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LinhaId",
                table: "Paradas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Linhas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linhas", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_Linhas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropTable(
                name: "Linhas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Paradas");
        }
    }
}