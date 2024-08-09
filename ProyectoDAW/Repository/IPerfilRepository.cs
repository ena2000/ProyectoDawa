using ProyectoDAW.Models;

namespace ProyectoDAW.Repository
{
    public interface IPerfilRepository
    {
        Task<IEnumerable<Perfil>> GetPerfiles();
        Task<Perfil> GetPerfilById(int id);
        Task<int> AddPerfil(Perfil perfil);
        Task<Perfil> UpdatePerfil(Perfil perfil);
        Task<int> DeletePerfil(int id);
    }
}
