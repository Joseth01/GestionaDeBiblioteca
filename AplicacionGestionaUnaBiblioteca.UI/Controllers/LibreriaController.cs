using AplicacionqueGestionaUnaBiblioteca.BL;
using AplicacionqueGestionaUnaBiblioteca.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AplicacionGestionaUnaBiblioteca.UI.Controllers
{
   
    public class LibreriaController : Controller
    {
        GestorDeLaBiblioteca elGestor;
        public LibreriaController(IMemoryCache elCache)
        {
            
            elGestor = new GestorDeLaBiblioteca(elCache);

        }
        // GET: LibreriaController
        public ActionResult Index()
        {
            Libro elLibro = new Libro();
            elLibro.elId = 1;
            elLibro.elNombre = "El Principito";
            elLibro.laDescripcion = "Un libro sobre un niño que viaja por el espacio";
            elLibro.laFechaDePublicacion = new DateTime(1943, 4, 6);
            elLibro.elTipo = TiposDeLibro.DeViaje;
            elLibro.elEstado = EstadoDeLibro.Disponible;
            elLibro.laUltimaFechaDeDevolucion = null;

            List<Libro> laListaDeLibros = new List<Libro>();
            laListaDeLibros.Add(elLibro);

            return View(laListaDeLibros);
        }

        // GET: LibreriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibreriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibreriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro ellibro)
        {
            elGestor.RegistreUnLibro(ellibro);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibreriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibreriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibreriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibreriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
