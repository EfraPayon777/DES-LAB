namespace Biblioteca.Entites.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int EditorialId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
