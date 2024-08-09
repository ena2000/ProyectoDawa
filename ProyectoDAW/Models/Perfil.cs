using System.ComponentModel.DataAnnotations;

namespace ProyectoDAW.Models
{
    public class Perfil
    {
        [Key]
        public int PerfilId { get; set; }
        public string NombrePerfil { get; set;} = null!;
        public string ApellidosPerfil { get; set;} = null!;

        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public string EmailPerfil { get; set; } = null!;
        public string UsuarioPerfil { get; set; } = null!;
        public string PasswordPerfil { get; set; } = null!;
        public bool EstadoPerfil { get; set; }
    }
}
