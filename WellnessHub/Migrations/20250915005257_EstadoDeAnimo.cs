using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessHub.Migrations
{
    /// <inheritdoc />
    public partial class EstadoDeAnimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosDeAnimo",
                schema: "dbo", // <-- Aquí especificas el esquema
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Energia = table.Column<int>(type: "int", nullable: false),
                    NivelDeEstres = table.Column<int>(type: "int", nullable: false),
                    HorasDeSueno = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDeAnimo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosDeAnimo",
                schema: "dbo"); // <-- También aquí
        }
    }
}

