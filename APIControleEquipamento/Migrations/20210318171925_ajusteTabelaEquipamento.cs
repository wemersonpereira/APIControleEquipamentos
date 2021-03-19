using Microsoft.EntityFrameworkCore.Migrations;

namespace APIControleEquipamento.Migrations
{
    public partial class ajusteTabelaEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Cautelas_CautelaId",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<int>(
                name: "CautelaId",
                table: "Equipamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Cautelas_CautelaId",
                table: "Equipamentos",
                column: "CautelaId",
                principalTable: "Cautelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Cautelas_CautelaId",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<int>(
                name: "CautelaId",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Cautelas_CautelaId",
                table: "Equipamentos",
                column: "CautelaId",
                principalTable: "Cautelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
