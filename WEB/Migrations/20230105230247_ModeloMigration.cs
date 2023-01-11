using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Migrations
{
    /// <inheritdoc />
    public partial class ModeloMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "marca_id",
                table: "Modelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_marca_id",
                table: "Modelos",
                column: "marca_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_marca_id",
                table: "Modelos",
                column: "marca_id",
                principalTable: "Marcas",
                principalColumn: "marca_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_marca_id",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_marca_id",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "marca_id",
                table: "Modelos");
        }
    }
}
