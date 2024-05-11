using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Materia
    {
        
        public string NombreMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public int IdMateria { get; set; }
    }
}
