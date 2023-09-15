using System.ComponentModel.DataAnnotations;

namespace Usuarios_Dapper.Modelos
{
    public class Claimcito
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string claim { get; set; }
        [Required]
        public string valor { get; set; }

    }
}
