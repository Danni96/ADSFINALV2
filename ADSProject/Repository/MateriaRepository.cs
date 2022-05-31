using ADSProject.Data;
using ADSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        //private readonly List<MateriaViewModel> lstMaterias;
        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarMateria(MateriaViewModel materiaViewModel)
        {
            try
            {
                applicationDbContext.Materias.Add(materiaViewModel);
                applicationDbContext.SaveChanges();
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel)
        {
            try
            {
                //lstMaterias[lstMaterias.FindIndex(x => x.idMateria == idMateria)] = materiaViewModel;
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);


                applicationDbContext.Entry(item).CurrentValues.SetValues(materiaViewModel);

                applicationDbContext.SaveChanges();
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarMateria(int idMateria)
        {
            try
            {
                //lstMaterias.RemoveAt(lstMaterias.FindIndex(x => x.idMateria == idMateria));
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                //Borrar registro por completo
                //applicationDbContext.Materias.Remove(item);

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


        public MateriaViewModel ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                //var item = lstMaterias.Find(x => x.idMateria == idMateria);
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<MateriaViewModel> obtenerMateria()
        {
            try
            {
                //Obtener todos las Materias sin filtro (estado =1)
                return applicationDbContext.Materias.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MateriaViewModel> obtenerMateria(String[] includes)
        {
            try
            {
                // Se obtiene el listado de estudiantes donde la propiedad estado sea verdadero. (es decir que esten habilitados)
                var lst = applicationDbContext.Materias.Where(x => x.estado == true).AsQueryable();

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
