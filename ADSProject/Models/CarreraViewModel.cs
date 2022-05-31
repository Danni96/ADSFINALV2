using ADSProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Models
{
    public class CarreraViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int idCarrera { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud máxima del campo debe ser de 50 caracteres.")]
        [Display(Name = "Codigo")]
        public string CodigoCarrera { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 5 caracteres.")]
        [Display(Name = "Nombre")]
        public string NombreCarrera { get; set; }

        public bool estado { get; set; }
    }
}
