using ProyectoDAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public ProductoRepository(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public async Task<int> AddProducto(Producto Producto)
        {
            _restauranteDbContext.productos.Add(Producto);
            await _restauranteDbContext.SaveChangesAsync();

            return Producto.ProductoId;
        }

        /*public async Task<int> CambiarEstadoProducto(int ProductoId)
        {
            Producto Producto = await context.Producto.FindAsync(ProductoId);

            // Alternar el estado entre 1 y 0
            Producto.Estado = Producto.Estado == 0 ? 1 : 0;

            await context.SaveChangesAsync();
            return Producto.Id;
        }
       */

        public async Task<int> DeleteProducto(int ProductoId)
        {
            Producto Producto = await _restauranteDbContext.productos.FindAsync(ProductoId);
            if (Producto == null)
            {
                // Maneja el caso donde no se encuentra el Producto
                throw new Exception("Producto no encontrado");
            }

            // Alternar el estado booleano
            Producto.ProductoEstado = !Producto.ProductoEstado;

            await _restauranteDbContext.SaveChangesAsync();

            return Producto.ProductoId;
        }


        public async Task<Producto> GetProductoById(int ProductoId)
        {
            return await _restauranteDbContext.productos.FindAsync(ProductoId);

        }

        public async Task<Producto> UpdateProducto(Producto Producto)
        {
            //obtener el objeto de la BD
            Producto ProductoMod = await _restauranteDbContext.productos.FindAsync(Producto.ProductoId);
            //cambiar los valores del objeto consultado
            ProductoMod.CategoriaId = Producto.CategoriaId;
            ProductoMod.ProductoNombre = Producto.ProductoNombre;
            ProductoMod.ProductoDescripcion = Producto.ProductoDescripcion;
            ProductoMod.ProductoPrecio = Producto.ProductoPrecio;
            ProductoMod.ProductoEstado = Producto.ProductoEstado;
            //Guardar los cambios
            await _restauranteDbContext.SaveChangesAsync();
            return ProductoMod;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _restauranteDbContext.productos.ToListAsync();
        }


    }
}
