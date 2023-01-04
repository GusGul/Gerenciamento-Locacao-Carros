using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_carro_id",
                table: "Pedidos",
                column: "carro_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_cliente_id",
                table: "Pedidos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_marca_id",
                table: "Carros",
                column: "marca_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_modelo_id",
                table: "Carros",
                column: "modelo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Marcas_marca_id",
                table: "Carros",
                column: "marca_id",
                principalTable: "Marcas",
                principalColumn: "marca_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_modelo_id",
                table: "Carros",
                column: "modelo_id",
                principalTable: "Modelos",
                principalColumn: "modelo_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Carros_carro_id",
                table: "Pedidos",
                column: "carro_id",
                principalTable: "Carros",
                principalColumn: "carro_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_cliente_id",
                table: "Pedidos",
                column: "cliente_id",
                principalTable: "Clientes",
                principalColumn: "cliente_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Marcas_marca_id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_modelo_id",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Carros_carro_id",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_cliente_id",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_carro_id",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_cliente_id",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Carros_marca_id",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_modelo_id",
                table: "Carros");
        }
    }
}
