using Microsoft.EntityFrameworkCore.Migrations;

namespace APIControleEquipamento.Migrations
{
    public partial class addvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Cautelas");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Cautelas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Cautelas");

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Cautelas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
