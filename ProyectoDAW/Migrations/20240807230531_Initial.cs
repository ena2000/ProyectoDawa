using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDAW.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metodoPago = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    MontoPago = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "perfils",
                columns: table => new
                {
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPerfil = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    UsuarioPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPerfil = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfils", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    UsuarioPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ProductoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoPrecio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductoEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_productos_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resenas",
                columns: table => new
                {
                    ResenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    resenaEnum = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resenas", x => x.ResenaId);
                    table.ForeignKey(
                        name: "FK_resenas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    precioCarrito = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    estadoCarritoEnum = table.Column<int>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritos", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_carritos_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_inventario_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_compras_carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compras_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facturacions",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    IvaFactura = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalFactura = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    estadoFactura = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturacions", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_facturacions_compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturacions_pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturacions_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carritos_ProductoId",
                table: "carritos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_compras_CarritoId",
                table: "compras",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_compras_UsuarioId",
                table: "compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_facturacions_CompraId",
                table: "facturacions",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_facturacions_PagoId",
                table: "facturacions",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturacions_UsuarioId",
                table: "facturacions",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_ProductoId",
                table: "inventario",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_ProveedorId",
                table: "inventario",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_UsuarioId",
                table: "resenas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facturacions");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "perfils");

            migrationBuilder.DropTable(
                name: "resenas");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "carritos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
