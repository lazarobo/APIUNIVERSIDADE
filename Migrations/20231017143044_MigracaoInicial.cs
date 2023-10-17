using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apiUniversidade.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Duracao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    CursoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    CargaHoraria = table.Column<int>(type: "integer", nullable: false),
                    Semestre = table.Column<int>(type: "integer", nullable: false),
                    CursoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoID",
                table: "Alunos",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoID",
                table: "Disciplinas",
                column: "CursoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
