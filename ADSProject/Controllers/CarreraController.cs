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
    public class CarreraController : Controller
    {
        private readonly ICarreraRepository carreraRepository;

        public CarreraController(ICarreraRepository carreraRepository)
        {
            this.carreraRepository = carreraRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = carreraRepository.obtenerCarrera();
                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Form(int? idCarrera, Operaciones operaciones)
        {
            try
            {
                var carrera = new CarreraViewModel();
                if (idCarrera.HasValue)
                {
                    carrera = carreraRepository.obtenerCarreraPorID(idCarrera.Value);

                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;
                return View(carrera);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Form(CarreraViewModel carreraViewModel)
        {
            try
            {
                if (carreraViewModel.idCarrera == 0) // En caso de insertar
                {
                    carreraRepository.agregarCarrera(carreraViewModel);
                }
                else // En caso de actualizar
                {
                    carreraRepository.actualizarCarrera(carreraViewModel.idCarrera, carreraViewModel);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Delete(int idCarrera)
        {
            try
            {
                carreraRepository.eliminarCarrera(idCarrera);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
