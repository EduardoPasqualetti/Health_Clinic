using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Health_Clinic.Migrations
{
    /// <inheritdoc />
    public partial class BD_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHorario",
                table: "Consulta");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Consulta",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Horario",
                table: "Consulta",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Consulta");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHorario",
                table: "Consulta",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }
    }
}
