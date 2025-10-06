using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesol.Migrations
{
    /// <inheritdoc />
    public partial class AlterarResultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Resultado",
                table: "Leitura",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Resultado",
                table: "Leitura",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }
    }
}
