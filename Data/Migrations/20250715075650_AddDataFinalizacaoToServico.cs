using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFreela.Migrations
{
    /// <inheritdoc />
    public partial class AddDataFinalizacaoToServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinalizacao",
                table: "Servicos",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinalizacao",
                table: "Servicos");
        }
    }
}
