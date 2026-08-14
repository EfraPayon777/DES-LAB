using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.DAL.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetCategoriasAsync();
        Task<Categoria?> GetCategoriaByIdAsync(int id);
        Task<int> InsertCategoriaAsync(Categoria categoria);
        Task<Categoria?> UpdateCategoriaAsync(Categoria categoria);
        Task<bool> DeleteCategoriaAsync(int id);
    }
}
