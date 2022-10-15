using System.ComponentModel.DataAnnotations;

namespace Usuarios_Dapper.Modelos
{
    public class Usuario
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string password { get; set; }
        public int intentos { get; set; }
        public string bloqueado { get; set; }
        public string rol { get; set; }

    }
}
