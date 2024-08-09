using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ProyectoDAW.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string ProductoNombre { get; set; } = null!;
        public string ProductoDescripcion { get; set; } = null!;

        [Precision(18, 2)]
        public decimal ProductoPrecio { get; set; }
        public bool ProductoEstado { get; set; }


    }
}
