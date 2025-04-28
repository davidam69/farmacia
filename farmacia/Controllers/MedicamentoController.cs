// Controllers/MedicamentoController.cs
using Microsoft.AspNetCore.Mvc;
using FarmaciaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FarmaciaApp.Controllers
{
    public class MedicamentoController : Controller
    {
        // Simulamos una base de datos en memoria
        private static List<Medicamento> medicamentos = new List<Medicamento>
        {
            new Medicamento { id = 1, nombre = "Paracetamol", precio = 500, stock = 20 },
            new Medicamento { id = 2, nombre = "Ibuprofeno", precio = 600, stock = 15 }
        };

        public IActionResult Index()
        {
            return View(medicamentos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Medicamento nuevo)
        {
            if (ModelState.IsValid)
            {
                nuevo.id = medicamentos.Max(m => m.id) + 1;
                medicamentos.Add(nuevo);
                return RedirectToAction("Index");
            }
            return View(nuevo);
        }

        public IActionResult Detalles(int id)
        {
            var medicamento = medicamentos.FirstOrDefault(m => m.id == id);
            if (medicamento == null) return NotFound();
            return View(medicamento);
        }
    }
}

