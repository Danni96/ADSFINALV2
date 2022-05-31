using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IGrupoRepository
    {
        List<GrupoViewModel> obtenerGrupos();

        List<GrupoViewModel> obtenerGrupos(String[] includes);

        int agregarGrupo(GrupoViewModel grupoViewModel);

        int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel);

        bool eliminarGrupo(int idGrupo);

        GrupoViewModel obtenerGrupoPorID(int idGrupo);
    }
}
