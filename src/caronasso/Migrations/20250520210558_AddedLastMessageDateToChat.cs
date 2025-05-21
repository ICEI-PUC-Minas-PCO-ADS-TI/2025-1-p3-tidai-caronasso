using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace caronasso.Migrations
{
    /// <inheritdoc />
    public partial class AddedLastMessageDateToChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioEnvio",
                table: "Chats",
                newName: "UltimaMensagemData");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Chats",
                newName: "Titulo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Chats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "UltimaMensagemData",
                table: "Chats",
                newName: "HorarioEnvio");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Chats",
                newName: "Conteudo");
        }
    }
}
