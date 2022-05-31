using ADSProject.Models;
using ADSProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ADSProject.Repository
{
    public class GrupoRepository : IGrupoRepository
    {

        //private readonly List<GrupoViewModel> lstGrupos;
        private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {

                applicationDbContext.Grupos.Add(grupoViewModel);
                applicationDbContext.SaveChanges();

                return grupoViewModel.idGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarGrupo(int idGrupo, GrupoViewModel grupoViewModel)
        {
            try
            {
                //lstEstudiantes[lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante)] = estudianteViewModel;
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);


                applicationDbContext.Entry(item).CurrentValues.SetValues(grupoViewModel);

                applicationDbContext.SaveChanges();

                return grupoViewModel.idGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarGrupo(int idGrupo)
        {
            try
            {
                //lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(x => x.idEstudiante == idEstudiante));
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);

                //Borrar registro por completo
                //applicationDbContext.Estudiantes.Remove(item);

                item.estado = false;
                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;
                applicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GrupoViewModel obtenerGrupoPorID(int idGrupo)
        {
            try
            {
                //var item = lstEstudiantes.Find(x => x.idEstudiante == idEstudiante);
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.idGrupo == idGrupo);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GrupoViewModel> obtenerGrupos()
        {
            try
            {
                //Obtener todos los estudiantes sin filtro
                //return applicationDbContext.Estudiantes.ToList();

                //Obtener todos los estudiantes sin filtro (estado =1)
                return applicationDbContext.Grupos.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GrupoViewModel> obtenerGrupos(String[] includes)
        {
            try
            {
                // Se obtiene el listado de estudiantes donde la propiedad estado sea verdadero. (es decir que esten habilitados)
                var lst = applicationDbContext.Grupos.Where(x => x.estado == true).AsQueryable();

                foreach (var item in includes)
                {
                    lst = lst.Include(item);
                }

                return lst.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
