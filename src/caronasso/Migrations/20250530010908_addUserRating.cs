using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace caronasso.Migrations
{
    /// <inheritdoc />
    public partial class addUserRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacoesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioAvaliadoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAvaliadorId = table.Column<int>(type: "int", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacoesUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacoesUsuarios_Usuarios_UsuarioAvaliadoId",
                        column: x => x.UsuarioAvaliadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacoesUsuarios_Usuarios_UsuarioAvaliadorId",
                        column: x => x.UsuarioAvaliadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesUsuarios_UsuarioAvaliadoId",
                table: "AvaliacoesUsuarios",
                column: "UsuarioAvaliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesUsuarios_UsuarioAvaliadorId",
                table: "AvaliacoesUsuarios",
                column: "UsuarioAvaliadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacoesUsuarios");
        }
    }
}
