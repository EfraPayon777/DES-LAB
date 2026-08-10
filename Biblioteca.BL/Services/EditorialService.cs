using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entites.Dtos;
using Biblioteca.Entites.Models;

namespace Biblioteca.BL.Services
{
    public class EditorialService(IEditorialRepository editorialRepository, IMapper mapper) : IEditorialService
    {
        public async Task<List<EditorialDto>> GetEditorialesAsync()
        {
            var editoriales = await editorialRepository.GetEditorialesAsync();
            return mapper.Map<List<EditorialDto>>(editoriales);
        }

        public async Task<EditorialDto?> GetEditorialByIdAsync(int id)
        {
            var editorial = await editorialRepository.GetEditorialByIdAsync(id);
            return editorial is null ? null : mapper.Map<EditorialDto>(editorial);
        }

        public async Task<int> InsertEditorialAsync(EditorialDto editorialDto)
        {
            var editorial = mapper.Map<Editorial>(editorialDto);
            return await editorialRepository.InsertEditorialAsync(editorial);
        }

        public async Task<EditorialDto?> UpdateEditorialAsync(EditorialDto editorialDto)
        {
            var editorial = mapper.Map<Editorial>(editorialDto);
            var result = await editorialRepository.UpdateEditorialAsync(editorial);
            return result is null ? null : mapper.Map<EditorialDto>(result);
        }

        public async Task<bool> DeleteEditorialAsync(int id)
        {
            return await editorialRepository.DeleteEditorialAsync(id);
        }
    }
}
