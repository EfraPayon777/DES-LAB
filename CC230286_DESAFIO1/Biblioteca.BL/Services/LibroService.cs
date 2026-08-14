using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.DAL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.BL.Services
{
    public class LibroService(ILibroRepository repository, IMapper mapper) : ILibroService
    {
        public async Task<List<LibroDto>> GetAllLibrosAsync()
        {
            try
            {
                var result = await repository.GetLibrosAsync();
                return mapper.Map<List<Libro>, List<LibroDto>>(result);
            }
            catch { return []; }
        }

        public async Task<LibroDto?> GetLibroByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetLibrosAsync(); // O GetLibroByIdAsync
                var libro = result.FirstOrDefault(x => x.Id == id);
                return libro == null ? null : mapper.Map<Libro, LibroDto>(libro);
            }
            catch { return null; }
        }

        public async Task<int> InsertLibroAsync(LibroDto libroDto)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(libroDto);
                return await repository.InsertLibroAsync(entity);
            }
            catch { return -1; }
        }

        public async Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto)
        {
            try
            {
                var entity = mapper.Map<LibroDto, Libro>(libroDto);
                var result = await repository.UpdateLibroAsync(entity);
                return result == null ? null : mapper.Map<Libro, LibroDto>(result);
            }
            catch { return null; }
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            try { return await repository.DeleteLibroAsync(id); }
            catch { return false; }
        }
    }
}