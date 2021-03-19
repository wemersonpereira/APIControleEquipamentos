using Microsoft.EntityFrameworkCore.Migrations;

namespace APIControleEquipamento.Migrations
{
    public partial class PopulaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Pessoas(TipoPessoa,Nome,CPF,Matricula) values('Terceirizado','Wemerson Pereira','04931827489','123456789')");

            //migrationBuilder.Sql("insert into Cautelas(Descricao,DataCadastro,PessoaId) values('Declaro para os devidos fins de cautela',CURRENT_TIMESTAMP," +
                //"(select PessoaId from Pessoas where TipoPessoa='Terceirizado')))");

            //migrationBuilder.Sql("insert into Equipamentos(TipoEquipamento,Marca,Modelo,NumeroControle,CautelaId) values ('Smartphone','Motorola','E5','354140097844993'," +
                //"(select Id from Cautelas where Id=1))");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Pessoas");
            migrationBuilder.Sql("Delete from Equipamentos");
            migrationBuilder.Sql("Delete from Cautelas");
        }
    }
}
