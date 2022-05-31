using ADSProject.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int idMateria { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Nombre Materia")]
        public string nombreMateria { get; set; }

        public bool estado { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]

        public int idCarrera { get; set; }

        [ForeignKey("idCarrera")]
        public CarreraViewModel Carreras { get; set; }
    }
}
