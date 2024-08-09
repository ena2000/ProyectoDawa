using ProyectoDAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public PerfilRepository(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public async Task<int> AddPerfil(Perfil Perfil)
        {
            _restauranteDbContext.perfils.Add(Perfil);
            await _restauranteDbContext.SaveChangesAsync();

            return Perfil.PerfilId;
        }

        /*public async Task<int> CambiarEstadoPerfil(int PerfilId)
        {
            Perfil Perfil = await context.Perfil.FindAsync(PerfilId);

            // Alternar el estado entre 1 y 0
            Perfil.Estado = Perfil.Estado == 0 ? 1 : 0;

            await context.SaveChangesAsync();
            return Perfil.Id;
        }
       */

        public async Task<int> DeletePerfil(int PerfilId)
        {
            Perfil Perfil = await _restauranteDbContext.perfils.FindAsync(PerfilId);
            if (Perfil == null)
            {
                // Maneja el caso donde no se encuentra el Perfil
                throw new Exception("Perfil no encontrado");
            }

            // Alternar el estado booleano
            Perfil.EstadoPerfil = !Perfil.EstadoPerfil;

            await _restauranteDbContext.SaveChangesAsync();

            return Perfil.PerfilId;
        }


        public async Task<Perfil> GetPerfilById(int PerfilId)
        {
            return await _restauranteDbContext.perfils.FindAsync(PerfilId);

        }

        public async Task<Perfil> UpdatePerfil(Perfil Perfil)
        {
            //obtener el objeto de la BD
            Perfil PerfilMod = await _restauranteDbContext.perfils.FindAsync(Perfil.PerfilId);
            //cambiar los valores del objeto consultado
            PerfilMod.NombrePerfil = Perfil.NombrePerfil;
            PerfilMod.ApellidosPerfil = Perfil.ApellidosPerfil;
            PerfilMod.EmailPerfil = Perfil.EmailPerfil;
            PerfilMod.UsuarioPerfil = Perfil.UsuarioPerfil;
            PerfilMod.EstadoPerfil = Perfil.EstadoPerfil;
            //Guardar los cambios
            await _restauranteDbContext.SaveChangesAsync();
            return PerfilMod;
        }

        public async Task<IEnumerable<Perfil>> GetPerfiles()
        {
            return await _restauranteDbContext.perfils.ToListAsync();
        }


    }
}
