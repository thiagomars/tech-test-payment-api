using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace techtestpaymentapi.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "venda",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    idvendedor = table.Column<int>(name: "id_vendedor", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_venda_vendedor_id_vendedor",
                        column: x => x.idvendedor,
                        principalTable: "vendedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idvenda = table.Column<int>(name: "id_venda", type: "integer", nullable: false),
                    iditens = table.Column<int>(name: "id_itens", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_compra_itens_id_itens",
                        column: x => x.iditens,
                        principalTable: "itens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compra_venda_id_venda",
                        column: x => x.idvenda,
                        principalTable: "venda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compra_id_itens",
                table: "compra",
                column: "id_itens");

            migrationBuilder.CreateIndex(
                name: "IX_compra_id_venda",
                table: "compra",
                column: "id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_venda_id_vendedor",
                table: "venda",
                column: "id_vendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "itens");

            migrationBuilder.DropTable(
                name: "venda");

            migrationBuilder.DropTable(
                name: "vendedor");
        }
    }
}
