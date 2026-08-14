using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Dtos;

namespace CC230396_Desafio01.BL.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> GetAllCategoriasAsync();
        Task<CategoriaDto?> GetCategoriaByIdAsync(int id);
        Task<int> InsertCategoriaAsync(CategoriaDto categoriaDto);
        Task<CategoriaDto?> UpdateCategoriaAsync(CategoriaDto categoriaDto);
        Task<bool> DeleteCategoriaAsync(int id);
    }
}