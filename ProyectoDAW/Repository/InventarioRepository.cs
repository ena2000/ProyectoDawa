using ProyectoDAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public InventarioRepository(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public async Task<int> Crear(Inventario Inventario)
        {
            _restauranteDbContext.inventario.Add(Inventario);
            await _restauranteDbContext.SaveChangesAsync();

            return Inventario.InventarioId;
        }

        /*public async Task<int> CambiarEstadoInventario(int InventarioId)
        {
            Inventario Inventario = await context.Inventario.FindAsync(InventarioId);

            // Alternar el estado entre 1 y 0
            Inventario.Estado = Inventario.Estado == 0 ? 1 : 0;

            await context.SaveChangesAsync();
            return Inventario.Id;
        }
       */

        public async Task<int> CambiarEstadoInventario(int InventarioId)
        {
            Inventario inventario = await _restauranteDbContext.inventario.FindAsync(InventarioId);
            if (inventario == null)
            {
                // Maneja el caso donde no se encuentra el inventario
                throw new Exception("Inventario no encontrado");
            }

            // Alternar el estado booleano
            inventario.Estado = !inventario.Estado;

            await _restauranteDbContext.SaveChangesAsync();

            return inventario.InventarioId;
        }


        public async Task<Inventario?> ObtenerPorId(int InventarioId)
        {
            return await _restauranteDbContext.inventario.FindAsync(InventarioId);

        }

        public async Task<Inventario> ModificarInventario(Inventario Inventario)
        {
            //obtener el objeto de la BD
            Inventario InventarioMod = await _restauranteDbContext.inventario.FindAsync(Inventario.InventarioId);
            //cambiar los valores del objeto consultado
            InventarioMod.ProductoId = Inventario.ProductoId;
            InventarioMod.ProveedorId = Inventario.ProveedorId;
            InventarioMod.Cantidad = Inventario.Cantidad;
            InventarioMod.Precio = Inventario.Precio;
            InventarioMod.Tipo = Inventario.Tipo;
            //Guardar los cambios
            await _restauranteDbContext.SaveChangesAsync();
            return InventarioMod;
        }

        public Task<List<Inventario>> ObtenerTodos()
        {
            //return context.Inventarios.ToListAsync();
            return _restauranteDbContext.inventario
            .Include(Inventario => Inventario.Producto)
            .Include(Inventario => Inventario.Proveedor)
            .ToListAsync();
        }


    }
}
