using System.ComponentModel.DataAnnotations;

namespace ExamenUnidadUnoAPI.Entities
{
    public class PersonEntity
    {
        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El DNI debe tener 13 caracteres")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Gender { get; set; }
    }
}