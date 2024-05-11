using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Profesor
    {
        public string NombresProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres.")]
        public string ApellidosProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico no e correcto.")]

         public int IdProfesor { get; set; }
    }
}