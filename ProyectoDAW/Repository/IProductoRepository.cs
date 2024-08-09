using ProyectoDAW.Models;

namespace ProyectoDAW.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task<int> AddProducto(Producto producto);
        Task<Producto> UpdateProducto(Producto producto);
        Task<int> DeleteProducto(int id);
    }
}
