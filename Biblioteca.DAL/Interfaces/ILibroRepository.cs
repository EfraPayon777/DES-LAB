using Biblioteca.Entites.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetLibrosAsync();
        Task<Libro?> GetLibroByIdAsync(int id);
        Task<List<Libro>> GetLibrosByEditorialIdAsync(int editorialId);
        Task<int> InsertLibroAsync(Libro libro);
        Task<Libro?> UpdateLibroAsync(Libro libro);
        Task<bool> DeleteLibroAsync(int id);
    }
}
