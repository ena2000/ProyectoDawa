using ProyectoDAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public class ReseñaRepository : IReseñaRepository
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public ReseñaRepository(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public async Task<int> AddResena(Resena Resenas)
        {
            _restauranteDbContext.resenas.Add(Resenas);
            await _restauranteDbContext.SaveChangesAsync();

            return Resenas.ResenaId;
        }

        /*public async Task<int> CambiarEstadoResena(int ResenaId)
        {
            Resena Resena = await context.Resena.FindAsync(ResenaId);

            // Alternar el estado entre 1 y 0
            Resena.Estado = Resena.Estado == 0 ? 1 : 0;

            await context.SaveChangesAsync();
            return Resena.Id;
        }
       */

        /*public async Task<int> DeleteResena(int ResenaId)
        {
            Resena Resena = await _restauranteDbContext.resenas.FindAsync(ResenaId);
            if (Resena == null)
            {
                // Maneja el caso donde no se encuentra el Resena
                throw new Exception("Resena no encontrado");
            }

            // Alternar el estado booleano
            Resena.EstadoResena = !Resena.EstadoResena;

            await _restauranteDbContext.SaveChangesAsync();

            return Resena.ResenaId;
        }

        */

        public async Task<Resena> GetResenaById(int ResenaId)
        {
            return await _restauranteDbContext.resenas.FindAsync(ResenaId);

        }

        public async Task<Resena> UpdateResena(Resena Resena)
        {
            //obtener el objeto de la BD
            Resena ResenaMod = await _restauranteDbContext.resenas.FindAsync(Resena.ResenaId);
            //cambiar los valores del objeto consultado
            ResenaMod.UsuarioId = Resena.UsuarioId;
            ResenaMod.resenaEnum = Resena.resenaEnum;
            ResenaMod.Comentario = Resena.Comentario;
           
            //Guardar los cambios
            await _restauranteDbContext.SaveChangesAsync();
            return ResenaMod;
        }

        public async Task<IEnumerable<Resena>> GetResenas()
        {
            return await _restauranteDbContext.resenas.ToListAsync();
        }


    }
}
