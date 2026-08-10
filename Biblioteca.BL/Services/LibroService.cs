using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entites.Dtos;
using Biblioteca.Entites.Models;

namespace Biblioteca.BL.Services
{
    public class LibroService(ILibroRepository libroRepository, IMapper mapper) : ILibroService
    {
        public async Task<List<LibroDto>> GetLibrosAsync()
        {
            var libros = await libroRepository.GetLibrosAsync();
            return mapper.Map<List<LibroDto>>(libros);
        }

        public async Task<LibroDto?> GetLibroByIdAsync(int id)
        {
            var libro = await libroRepository.GetLibroByIdAsync(id);
            return libro is null ? null : mapper.Map<LibroDto>(libro);
        }

        public async Task<List<LibroDto>> GetLibrosByEditorialIdAsync(int editorialId)
        {
            var libros = await libroRepository.GetLibrosByEditorialIdAsync(editorialId);
            return mapper.Map<List<LibroDto>>(libros);
        }

        public async Task<int> InsertLibroAsync(LibroDto libroDto)
        {
            var libro = mapper.Map<Libro>(libroDto);
            return await libroRepository.InsertLibroAsync(libro);
        }

        public async Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto)
        {
            var libro = mapper.Map<Libro>(libroDto);
            var result = await libroRepository.UpdateLibroAsync(libro);
            return result is null ? null : mapper.Map<LibroDto>(result);
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            return await libroRepository.DeleteLibroAsync(id);
        }
    }
}
