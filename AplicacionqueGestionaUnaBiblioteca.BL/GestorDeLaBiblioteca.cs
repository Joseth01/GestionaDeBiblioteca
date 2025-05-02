using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionqueGestionaUnaBiblioteca.Model;
using Microsoft.Extensions.Caching.Memory;

namespace AplicacionqueGestionaUnaBiblioteca.BL
{
    public class GestorDeLaBiblioteca
    {
        private readonly IMemoryCache elCache;
        private const string laClaveDelCache = "Libros";

        public GestorDeLaBiblioteca(IMemoryCache cache)
        {
            elCache = cache;
        }

        public List<Libro> ObtengaLaLista()
        {
            List<Libro> laLista ;
            if (elCache.Get("Datos") is null)
            {
                laLista = new List<Libro>();
                elCache.Set("Datos", laLista);
            }
            else {
                laLista = elCache.Get("Datos") as List<Libro>;
            }

            return laLista;
        }

        public void RegistreUnLibro(Libro elNuevoLibro)
        {
            var laLista = ObtengaLaLista();

            elNuevoLibro.elId = laLista.Count + 1;
            elNuevoLibro.elEstado = EstadoDeLibro.Disponible;
      
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
            if (elLibro != null && elLibro.elEstado == EstadoDeLibro.Disponible)
            {
                elLibro.elEstado = EstadoDeLibro.Prestado;
            }
        }

        public void DevuelvaElLibro(int elId)
        {
            var elLibro = ObtengaElLibroPorId(elId);
            if (elLibro != null && elLibro.elEstado == EstadoDeLibro.Prestado)
            {
                elLibro.elEstado = EstadoDeLibro.Disponible;
                
            }
        }

        public List<Libro> ObtengaLosLibrosPrestados()
        {
            return ObtengaLaLista().Where(libro => libro.elEstado == EstadoDeLibro.Prestado).ToList();
        }
    }

}
