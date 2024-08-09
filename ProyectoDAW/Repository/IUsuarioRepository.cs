using ProyectoDAW.Models;
using System.Threading.Tasks;

namespace ProyectoDAW.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<int> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<int> DeleteUsuario(int id);
    }
}
