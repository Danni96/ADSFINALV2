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
    public class MateriaController : Controller
    {
        private readonly IMateriaRepository materiaRepository;
        private readonly ICarreraRepository carreraRepository;

        public MateriaController(IMateriaRepository materiaRepository, ICarreraRepository carreraRepository)
        {
            this.materiaRepository = materiaRepository;
            this.carreraRepository = carreraRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = materiaRepository.obtenerMateria(new String[] { "Carreras" });
                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Form (int? idMateria, Operaciones operaciones)
        {
            try
            {
                var materia = new MateriaViewModel();
                if(idMateria.HasValue)
                {
                    materia = materiaRepository.ObtenerMateriaPorID(idMateria.Value);
                    
                }
                ViewData["Operaciones"] = operaciones;

                // obteniendo todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarrera();

                return View(materia);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Form(MateriaViewModel materiaViewModel)
        {
            try
            {
                if (materiaViewModel.idMateria == 0) // En caso de insertar
                {
                    materiaRepository.agregarMateria(materiaViewModel);
                }
                else // En caso de actualizar
                {
                    materiaRepository.actualizarMateria
                        (materiaViewModel.idMateria, materiaViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Delete(int idMateria)
        {
            try
            {
                materiaRepository.eliminarMateria(idMateria);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
