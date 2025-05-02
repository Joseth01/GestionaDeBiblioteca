using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionGestionaUnaBiblioteca.UI.Controllers
{
    public class LibreriaController : Controller
    {
        // GET: LibreriaController
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(IFormCollection collection)
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
