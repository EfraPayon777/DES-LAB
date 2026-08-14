using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.DAL.Interfaces
{
    public interface IAutorRepository
    {
        public Task<List<Autor>> GetAutoresAsync();
        public Task<Autor?> GetAutorByIdAsync(int id);
        public Task<int> InsertAutorAsync(Autor autor);
        public Task<Autor?> UpdateAutorAsync(Autor autor);
        public Task<bool> DeleteAutorAsync(int id);
    }
}