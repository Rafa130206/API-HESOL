using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesol.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leitura",
                columns: table => new
                {
                    IdLeitura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Temperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Co2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Umidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Poluicao = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Resultado = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitura", x => x.IdLeitura);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    IdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Modelo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdLocal = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AtivoChar = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.IdSensor);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leitura");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
