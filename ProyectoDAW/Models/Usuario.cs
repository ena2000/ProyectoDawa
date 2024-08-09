using System.ComponentModel.DataAnnotations;

namespace ProyectoDAW.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = null!;
        public string UsuarioApellido { get; set;} = null!;
        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public string UsuarioEmail { get; set; } = null!;
        public string UsuarioPassword { get; set; } = null!;
        public string UsuarioDireccion { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        public string UsuarioTelefono { get; set; } = null!;
        public bool UsuarioEstado { get; set; }
    }
}
