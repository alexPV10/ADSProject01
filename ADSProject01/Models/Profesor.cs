using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdProfesor))]
    public class Profesor
    {
        public int IdProfesor { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres.")]
        public string NombresProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser menor a 12 caracteres.")]
        public string ApellidosProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico no es correcto.")]
        public string Email { get; set; }
    }
}