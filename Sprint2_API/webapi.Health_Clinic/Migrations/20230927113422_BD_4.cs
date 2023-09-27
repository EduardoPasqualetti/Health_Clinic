using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Health_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdInstituicao",
                table: "Clinica",
                newName: "IdClinica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdClinica",
                table: "Clinica",
                newName: "IdInstituicao");
        }
    }
}
