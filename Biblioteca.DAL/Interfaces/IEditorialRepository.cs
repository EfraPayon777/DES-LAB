using Biblioteca.Entites.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface IEditorialRepository
    {
        Task<List<Editorial>> GetEditorialesAsync();
        Task<Editorial?> GetEditorialByIdAsync(int id);
        Task<int> InsertEditorialAsync(Editorial editorial);
        Task<Editorial?> UpdateEditorialAsync(Editorial editorial);
        Task<bool> DeleteEditorialAsync(int id);
    }
}
