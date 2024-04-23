using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PacienteCpf = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteNome = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteData = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteGenero = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteTelefone = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteNotas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
