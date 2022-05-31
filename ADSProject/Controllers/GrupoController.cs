using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly ICarreraRepository carreraRepository;
        private readonly IMateriaRepository materiaRepository;
        private readonly IProfesorRepository profesorRepository;

        public GrupoController(IGrupoRepository grupoRepository, ICarreraRepository carreraRepository,IMateriaRepository materiaRepository ,IProfesorRepository profesorRepository)
        {
            this.grupoRepository = grupoRepository;
            this.carreraRepository = carreraRepository;
            this.materiaRepository = materiaRepository;
            this.profesorRepository = profesorRepository;
        }

      

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = grupoRepository.obtenerGrupos(new String[] { "Carreras" , "Profesores", "Materias"});
                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpGet]
        public IActionResult Form(int? idGrupo, Operaciones operaciones)
        {
            try
            {
                var grupo = new GrupoViewModel();

                if (idGrupo.HasValue)
                {
                    grupo = grupoRepository.obtenerGrupoPorID(idGrupo.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                // obteniendo todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarrera();
                ViewBag.Materias = materiaRepository.obtenerMateria();
                ViewBag.Profesor = profesorRepository.obtenerProfesor();
                return View(grupo);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(GrupoViewModel grupoViewModel)
        {
            try
            {
                if (grupoViewModel.idGrupo == 0) // En caso de insertar
                {
                    grupoRepository.agregarGrupo(grupoViewModel);
                }
                else // En caso de actualizar
                {
                    grupoRepository.actualizarGrupo(grupoViewModel.idGrupo, grupoViewModel);

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost] // se cambió a Post para eliminar el registro
        public IActionResult Delete(int idGrupo)
        {
            try
            {
                grupoRepository.eliminarGrupo(idGrupo);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
