using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.DAL.Interfaces;
using CC230396_Desafio01.Entities.Models;
using Dapper;

namespace CC230396_Desafio01.DAL.Repositories
{
    public class CategoriaRepository(IDatabaseRepository databaseRepository) : ICategoriaRepository
    {
        public async Task<List<Categoria>> GetCategoriasAsync() =>
            await databaseRepository.GetDataByQueryAsync<Categoria>("SELECT * FROM Categorias");

        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Categoria>("SELECT * FROM Categorias WHERE Id = @Id", parameters)).FirstOrDefault();
        }

        public async Task<int> InsertCategoriaAsync(Categoria categoria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", categoria.Nombre);
            return await databaseRepository.InsertAsync("INSERT INTO Categorias (Nombre) VALUES (@Nombre); SELECT CAST(SCOPE_IDENTITY() AS INT)", parameters);
        }

        public async Task<Categoria?> UpdateCategoriaAsync(Categoria categoria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", categoria.Id);
            parameters.Add("@Nombre", categoria.Nombre);
            await databaseRepository.UpdateAsync<Categoria>("UPDATE Categorias SET Nombre = @Nombre WHERE Id = @Id", parameters);
            return categoria;
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync("DELETE FROM Categorias WHERE Id = @Id", parameters);
        }
    }
}
