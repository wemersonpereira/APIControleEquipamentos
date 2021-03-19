using Microsoft.EntityFrameworkCore.Migrations;

namespace APIControleEquipamento.Migrations
{
    public partial class AddColunaAtivaCautela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Cautelas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Cautelas");
        }
    }
}
