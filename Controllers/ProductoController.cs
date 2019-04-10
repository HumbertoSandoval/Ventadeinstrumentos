using System.Linq;
using C8ProyectoFinalPorEquipos.Models;
using Microsoft.AspNetCore.Mvc;

namespace C8ProyectoFinalPorEquipos.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new SqliteDbContext())
            {
                var producto = db.Productos.ToList();
                return View(producto);
            }
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(ProductoViewModel producto)
        {
            if (producto != null && ModelState.IsValid)
            {
                using (var db = new SqliteDbContext())
                {
                    db.Add(producto);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        // https://localhost:5001/Producto/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new SqliteDbContext())
            {
                var producto = db.Productos.Find(id);
                if (producto != null)
                {
                    return View(producto);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductoViewModel producto)
        {
            if (ModelState.IsValid && id > 0)
            {
                using (var db = new SqliteDbContext())
                {
                    var productoExistente = db.Productos.Find(id);
                    if (productoExistente != null)
                    {
                        productoExistente.Nombre = producto.Nombre;
                        productoExistente.Precio = producto.Precio;
                        productoExistente.Existencia=producto.Existencia;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                using (var db = new SqliteDbContext())
                {
                    var producto = db.Productos.Find(id);
                    db.Remove(producto);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}