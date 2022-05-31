using ADSProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Models
{
    public class GrupoViewModel
    {
        [Key]
        [Display(Name = "ID Grupo")]
        public int idGrupo { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idCarrera { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idMateria { get; set; }

        [Display(Name = "Profesor")]
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int idProfesor { get; set; }

        [Display(Name = "Ciclo")]
        public String ciclo { get; set; }

        [Display(Name = "Anio")]
        public int anio { get; set; }

        public bool estado { get; set; }


        [ForeignKey("idCarrera")]
        public CarreraViewModel Carreras { get; set; }

        [ForeignKey("idMateria")]
        public MateriaViewModel Materias { get; set; }

        [ForeignKey("idProfesor")]
        public ProfesorViewModel Profesores { get; set; }
    }
}
