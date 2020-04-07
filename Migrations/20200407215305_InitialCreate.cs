using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacione.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstacionamento = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    PrecoHora = table.Column<double>(nullable: false),
                    Avaliacao = table.Column<double>(nullable: false),
                    NumeroVagas = table.Column<int>(nullable: false),
                    NomeRua = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    Cep = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    TipoLogradouro = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamentos");
        }
    }
}
