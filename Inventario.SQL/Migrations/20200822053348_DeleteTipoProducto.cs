using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventario.SQL.Migrations
{
    public partial class DeleteTipoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoProducto_IdTipoProducto",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "TipoProducto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdTipoProducto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdTipoProducto",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "TipoProducto",
                table: "Producto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProducto",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoProducto",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoProducto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdTipoProducto",
                table: "Producto",
                column: "IdTipoProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoProducto_IdTipoProducto",
                table: "Producto",
                column: "IdTipoProducto",
                principalTable: "TipoProducto",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
