using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IEstudianteRepository
    {
        List<EstudianteViewModel> obtenerEstudiantes();

        List<EstudianteViewModel> obtenerEstudiantes(String[]includes);

        int agregarEstudiante(EstudianteViewModel estudianteViewModel);

        int actualizarEstudiante(int idEstudiante, EstudianteViewModel estudianteViewModel);

        bool eliminarEstudiante(int idEstudiante);

        EstudianteViewModel obtenerEstudiantePorID(int idEstudiante);
    }
}
