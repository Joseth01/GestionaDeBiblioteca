using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionqueGestionaUnaBiblioteca.Model;
using Microsoft.Extensions.Caching.Memory;

namespace AplicacionqueGestionaUnaBiblioteca.BL
{
    class GestorDeLaBiblioteca
    {
        private readonly IMemoryCache elCache;
        private const string laClaveDelCache = "Libros";

        public GestorDeLaBiblioteca(IMemoryCache cache)
        {
            elCache = cache;
        }

        public List<Libro> ObtengaLaLista()
        {
            if (!elCache.TryGetValue(laClaveDelCache, out List<Libro> laLista))
            {
                laLista = new List<Libro>();
                elCache.Set(laClaveDelCache, laLista);
            }

            return laLista;
        }

        public void RegistreUnLibro(Libro elNuevoLibro)
        {
            var laLista = ObtengaLaLista();

            elNuevoLibro.elId = laLista.Count + 1;
            elNuevoLibro.elEstado = "Disponible";
            elNuevoLibro.laUltimaFechaDeDevolucion = null;

            laLista.Add(elNuevoLibro);
            elCache.Set(laClaveDelCache, laLista);
        }

        public Libro ObtengaElLibroPorId(int elId)
        {
            return ObtengaLaLista().FirstOrDefault(libro => libro.elId == elId);
        }

        public void PresteElLibro(int elId)
        {
            var elLibro = ObtengaElLibroPorId(elId);
            if (elLibro != null && elLibro.elEstado == "Disponible")
            {
                elLibro.elEstado = "Prestado";
            }
        }

        public void DevuelvaElLibro(int elId)
        {
            var elLibro = ObtengaElLibroPorId(elId);
            if (elLibro != null && elLibro.elEstado == "Prestado")
            {
                elLibro.elEstado = "Disponible";
                elLibro.laUltimaFechaDeDevolucion = DateTime.Now;
            }
        }

        public List<Libro> ObtengaLosLibrosPrestados()
        {
            return ObtengaLaLista().Where(libro => libro.elEstado == "Prestado").ToList();
        }
    }

}
