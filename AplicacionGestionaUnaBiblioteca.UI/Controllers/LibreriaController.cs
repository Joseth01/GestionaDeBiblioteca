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
           
            List<Libro> laListaDeLibros = elGestor.ObtengaLaLista();


            return View(laListaDeLibros);
        }

        // GET: LibreriaController/Details/5
        public ActionResult Details(int id)
        {
            Libro elLibro = elGestor.ObtengaElLibroPorId(id);
            
            return View(elLibro);
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

        // GET: LibreriaController/Delete/5
        public ActionResult Prestar(int id)
        {
            elGestor.PresteElLibro(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Devolver(int id)
        {
            elGestor.DevuelvaElLibro(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Prestados()
        {
            var librosPrestados = elGestor.ObtengaLosLibrosPrestados().Where(elLibro => elLibro.elEstado == EstadoDeLibro.Prestado).ToList();
           
            return View(librosPrestados);

        }
    }
}
