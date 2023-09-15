using System.ComponentModel.DataAnnotations;

namespace Usuarios_Dapper.DTOs
{
    public class CredencialUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
