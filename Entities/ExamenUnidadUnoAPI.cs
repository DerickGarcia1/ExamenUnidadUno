using System.ComponentModel.DataAnnotations;

namespace ExamenUnidadUnoAPI.Entities
{
    public class PasswordRequest
    {
        [Required]
        public string Password { get; set; }
    }
}