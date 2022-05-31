using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface ICarreraRepository
    {
        List<CarreraViewModel> obtenerCarrera();

        int agregarCarrera(CarreraViewModel carreraViewModel);

        int actualizarCarrera(int idCarrera, CarreraViewModel carreraViewModel);

        bool eliminarCarrera(int idCarrera);

        CarreraViewModel obtenerCarreraPorID(int idCarrera);
    }
}
