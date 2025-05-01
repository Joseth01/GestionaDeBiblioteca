namespace AplicacionqueGestionaUnaBiblioteca.Model
{
    public class Libro
    {
        public int elId { get; set; }

        public string elNombre { get; set; }

        public string laDescripcion { get; set; }

        public DateTime laFechaDePublicacion { get; set; }

        public string elTipo { get; set; } 

        public string elEstado { get; set; } 
    }
}
