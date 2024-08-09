using System.ComponentModel.DataAnnotations;

namespace ProyectoDAW.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool CategoriaEstado { get; set; }
    }
}
