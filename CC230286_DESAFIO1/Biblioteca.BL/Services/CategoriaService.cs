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
    public class CategoriaService(ICategoriaRepository repository, IMapper mapper) : ICategoriaService
    {
        public async Task<List<CategoriaDto>> GetAllCategoriasAsync()
        {
            try
            {
                var result = await repository.GetCategoriasAsync();
                return mapper.Map<List<Categoria>, List<CategoriaDto>>(result);
            }
            catch { return []; }
        }

        public async Task<CategoriaDto?> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetCategoriaByIdAsync(id);
                return result == null ? null : mapper.Map<Categoria, CategoriaDto>(result);
            }
            catch { return null; }
        }

        public async Task<int> InsertCategoriaAsync(CategoriaDto categoriaDto)
        {
            try
            {
                var entity = mapper.Map<CategoriaDto, Categoria>(categoriaDto);
                return await repository.InsertCategoriaAsync(entity);
            }
            catch { return -1; }
        }

        public async Task<CategoriaDto?> UpdateCategoriaAsync(CategoriaDto categoriaDto)
        {
            try
            {
                var entity = mapper.Map<CategoriaDto, Categoria>(categoriaDto);
                var result = await repository.UpdateCategoriaAsync(entity);
                return result == null ? null : mapper.Map<Categoria, CategoriaDto>(result);
            }
            catch { return null; }
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            try { return await repository.DeleteCategoriaAsync(id); }
            catch { return false; }
        }
    }
}
