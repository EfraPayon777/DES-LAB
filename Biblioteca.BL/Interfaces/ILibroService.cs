using Biblioteca.Entites.Dtos;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        Task<List<LibroDto>> GetLibrosAsync();
        Task<LibroDto?> GetLibroByIdAsync(int id);
        Task<List<LibroDto>> GetLibrosByEditorialIdAsync(int editorialId);
        Task<int> InsertLibroAsync(LibroDto libroDto);
        Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto);
        Task<bool> DeleteLibroAsync(int id);
    }
}
