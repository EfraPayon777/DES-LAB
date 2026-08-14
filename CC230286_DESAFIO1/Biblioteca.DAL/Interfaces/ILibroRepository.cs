using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Models;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.DAL.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetLibrosAsync();
        Task<Libro?> GetLibroByIdAsync(int id);
        Task<int> InsertLibroAsync(Libro libro);
        Task<Libro?> UpdateLibroAsync(Libro libro);
        Task<bool> DeleteLibroAsync(int id);
    }
}