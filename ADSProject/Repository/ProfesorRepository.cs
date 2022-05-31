using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        //private readonly List<ProfesorViewModel> lstProfesores;
        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int agregarProfesor(ProfesorViewModel profesorViewModel)
        {
            try
            {
                applicationDbContext.Profesores.Add(profesorViewModel);
                applicationDbContext.SaveChanges();
                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int actualizarProfesor(int idProfesor, ProfesorViewModel profesorViewModel)
        {
            try
            {
                //lstProfesores[lstProfesores.FindIndex(x => x.idProfesor == idProfesor)] = profesorViewModel;
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);


                applicationDbContext.Entry(item).CurrentValues.SetValues(profesorViewModel);

                applicationDbContext.SaveChanges();
                return profesorViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarProfesor(int idProfesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

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

        public ProfesorViewModel obtenerProfesorPorID(int idProfesor)
        {
            try
            {
                //var item = lstProfesores.Find(x => x.idProfesor == idProfesor);
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProfesorViewModel> obtenerProfesor()
        {
            try
            {
                //Obtener todos los profesores sin filtro (estado =1)
                return applicationDbContext.Profesores.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
