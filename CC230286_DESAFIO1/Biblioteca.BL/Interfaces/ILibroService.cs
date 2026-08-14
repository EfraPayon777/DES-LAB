using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Dtos;

namespace CC230396_Desafio01.BL.Interfaces
{
    public interface ILibroService
    {
        Task<List<LibroDto>> GetAllLibrosAsync();
        Task<LibroDto?> GetLibroByIdAsync(int id);
        Task<int> InsertLibroAsync(LibroDto libroDto);
        Task<LibroDto?> UpdateLibroAsync(LibroDto libroDto);
        Task<bool> DeleteLibroAsync(int id);
    }
}