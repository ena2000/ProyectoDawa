using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDAW.Models;

namespace ProyectoDAW.Repositorynamespace
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> ObtenerTodos();
        Task<int> Crear(Proveedor Proveedor);
        Task<Proveedor> ModificarProveedor(Proveedor Proveedor);
        Task<int> CambiarEstadoProveedor(int ProveedorId);
        Task<Proveedor?> ObtenerPorId(int ProveedorId);
    }
}
