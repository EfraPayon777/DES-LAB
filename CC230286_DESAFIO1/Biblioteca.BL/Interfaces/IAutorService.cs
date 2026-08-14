using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Dtos;

namespace CC230396_Desafio01.BL.Interfaces
{
    public interface IAutorService
    {
        public Task<List<AutorDto>> GetAllAutoresAsync();
        public Task<AutorDto?> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(AutorDto autorDto);
        public Task<AutorDto?> UpdateAutorAsync(AutorDto autorDto);
        public Task<bool> DeleteAutorAsync(int id);
    }
}