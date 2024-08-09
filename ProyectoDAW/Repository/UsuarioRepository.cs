using ProyectoDAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public UsuarioRepository(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public async Task<int> AddUsuario(Usuario Usuarios)
        {
            _restauranteDbContext.usuarios.Add(Usuarios);
            await _restauranteDbContext.SaveChangesAsync();

            return Usuarios.UsuarioId;
        }

        /*public async Task<int> CambiarEstadoUsuario(int UsuarioId)
        {
            Usuario Usuario = await context.Usuario.FindAsync(UsuarioId);

            // Alternar el estado entre 1 y 0
            Usuario.Estado = Usuario.Estado == 0 ? 1 : 0;

            await context.SaveChangesAsync();
            return Usuario.Id;
        }
       */

        public async Task<int> DeleteUsuario(int UsuarioId)
        {
            Usuario Usuario = await _restauranteDbContext.usuarios.FindAsync(UsuarioId);
            if (Usuario == null)
            {
                // Maneja el caso donde no se encuentra el Usuario
                throw new Exception("Usuario no encontrado");
            }

            // Alternar el estado booleano
            Usuario.UsuarioEstado = !Usuario.UsuarioEstado;

            await _restauranteDbContext.SaveChangesAsync();

            return Usuario.UsuarioId;
        }


        public async Task<Usuario> GetUsuarioById(int UsuarioId)
        {
            return await _restauranteDbContext.usuarios.FindAsync(UsuarioId);

        }

        public async Task<Usuario> UpdateUsuario(Usuario Usuario)
        {
            //obtener el objeto de la BD
            Usuario UsuarioMod = await _restauranteDbContext.usuarios.FindAsync(Usuario.UsuarioId);
            //cambiar los valores del objeto consultado
            UsuarioMod.UsuarioNombre = Usuario.UsuarioNombre;
            UsuarioMod.UsuarioApellido = Usuario.UsuarioApellido;
            UsuarioMod.UsuarioEmail = Usuario.UsuarioEmail;
            UsuarioMod.UsuarioPassword = Usuario.UsuarioPassword;
            UsuarioMod.UsuarioDireccion = Usuario.UsuarioDireccion;
            UsuarioMod.UsuarioTelefono = Usuario.UsuarioTelefono;
            UsuarioMod.UsuarioEstado = Usuario.UsuarioEstado;
            //Guardar los cambios
            await _restauranteDbContext.SaveChangesAsync();
            return UsuarioMod;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _restauranteDbContext.usuarios.ToListAsync();
        }


    }
}
