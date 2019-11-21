using Microsoft.EntityFrameworkCore.Migrations;

namespace Personas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apellidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Cultura = table.Column<int>(nullable: false),
                    Comun = table.Column<int>(nullable: false),
                    EsCompuesto = table.Column<bool>(nullable: false),
                    IdIdioma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apellidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apellidos_Idiomas_IdIdioma",
                        column: x => x.IdIdioma,
                        principalTable: "Idiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nombres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Cultura = table.Column<int>(nullable: false),
                    Comun = table.Column<int>(nullable: false),
                    EsCompuesto = table.Column<bool>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    IdIdioma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nombres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nombres_Idiomas_IdIdioma",
                        column: x => x.IdIdioma,
                        principalTable: "Idiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    NumeroHabitantes = table.Column<int>(nullable: false),
                    Densidad = table.Column<int>(nullable: false),
                    PorcentajeIdiomaOficial = table.Column<int>(nullable: true),
                    GentilicioMasculino = table.Column<string>(maxLength: 100, nullable: true),
                    GentilicioFemenino = table.Column<string>(maxLength: 100, nullable: true),
                    IdIdiomaOficial = table.Column<int>(nullable: false),
                    IdIdiomaCooficial = table.Column<int>(nullable: true),
                    IdPais = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regiones_Idiomas_IdIdiomaCooficial",
                        column: x => x.IdIdiomaCooficial,
                        principalTable: "Idiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regiones_Idiomas_IdIdiomaOficial",
                        column: x => x.IdIdiomaOficial,
                        principalTable: "Idiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Regiones_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreProvincia = table.Column<string>(maxLength: 100, nullable: false),
                    GentilicioMasculino = table.Column<string>(maxLength: 100, nullable: true),
                    GentilicioFemenino = table.Column<string>(maxLength: 100, nullable: true),
                    IdRegion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincias_Regiones_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    IdProvincia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apellidos_IdIdioma",
                table: "Apellidos",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_IdProvincia",
                table: "Localidades",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Nombres_IdIdioma",
                table: "Nombres",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_IdRegion",
                table: "Provincias",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_IdIdiomaCooficial",
                table: "Regiones",
                column: "IdIdiomaCooficial");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_IdIdiomaOficial",
                table: "Regiones",
                column: "IdIdiomaOficial");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_IdPais",
                table: "Regiones",
                column: "IdPais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apellidos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Nombres");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
