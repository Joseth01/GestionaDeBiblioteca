namespace AplicacionqueGestionaUnaBiblioteca.Model
{
    public class Libro
    {
        public int elId { get; set; }

        public string elNombre { get; set; }

        public string laDescripcion { get; set; }

        public DateTime laFechaDePublicacion { get; set; }
        public TiposDeLibro elTipo { get; set; } 
        public EstadoDeLibro elEstado { get; set; }
        public List<DateTime> laUltimaFechaDeDevolucion { get; set; }

    }
}
