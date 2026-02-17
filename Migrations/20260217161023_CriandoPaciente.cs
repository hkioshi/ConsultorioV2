using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioV2.Migrations
{
    /// <inheritdoc />
    public partial class CriandoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContatoInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Rg = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoCivil = table.Column<string>(type: "TEXT", nullable: false),
                    PessoaResponsavelId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecomendadoPorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContatoInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProntuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomePai = table.Column<string>(type: "TEXT", nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    NomeConjuge = table.Column<string>(type: "TEXT", nullable: false),
                    Profissao = table.Column<string>(type: "TEXT", nullable: false),
                    ConheceuPor = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false),
                    Convenio = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroConvenio = table.Column<string>(type: "TEXT", nullable: false),
                    PreferenciaHorario = table.Column<string>(type: "TEXT", nullable: false),
                    QueroReceberLembretes = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_ContatoInfos_ContatoInfoId",
                        column: x => x.ContatoInfoId,
                        principalTable: "ContatoInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ContatoInfoId",
                table: "Pacientes",
                column: "ContatoInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ProntuarioId",
                table: "Pacientes",
                column: "ProntuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "ContatoInfos");

            migrationBuilder.DropTable(
                name: "Prontuarios");
        }
    }
}
