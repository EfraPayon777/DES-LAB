using Biblioteca.Entites.Dtos;

namespace Biblioteca.BL.Interfaces
{
    public interface IEditorialService
    {
        Task<List<EditorialDto>> GetEditorialesAsync();
        Task<EditorialDto?> GetEditorialByIdAsync(int id);
        Task<int> InsertEditorialAsync(EditorialDto editorialDto);
        Task<EditorialDto?> UpdateEditorialAsync(EditorialDto editorialDto);
        Task<bool> DeleteEditorialAsync(int id);
    }
}
