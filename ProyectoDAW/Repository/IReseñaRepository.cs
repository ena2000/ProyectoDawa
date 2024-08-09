using ProyectoDAW.Models;

namespace ProyectoDAW.Repository
{
    public interface IReseñaRepository
    {
        Task<IEnumerable<Resena>> GetResenas();
        Task<Resena> GetResenaById(int id);
        Task<int> AddResena(Resena resena);
        Task<Resena> UpdateResena(Resena resena);
        //Task<int> DeleteResena(int id);
    }
}
