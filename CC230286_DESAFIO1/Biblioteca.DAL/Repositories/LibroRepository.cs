using System;
using System.Collections.Generic;
using System.Text;
using CC230396_Desafio01.DAL.Interfaces;
using CC230396_Desafio01.Entities.Models;
using Dapper;

namespace CC230396_Desafio01.DAL.Repositories
{
    public class LibroRepository(IDatabaseRepository databaseRepository) : ILibroRepository
    {
        public async Task<List<Libro>> GetLibrosAsync() =>
            await databaseRepository.GetDataByQueryAsync<Libro>("SELECT * FROM Libros");

        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return (await databaseRepository.GetDataByQueryAsync<Libro>("SELECT * FROM Libros WHERE Id = @Id", parameters)).FirstOrDefault();
        }

        public async Task<int> InsertLibroAsync(Libro libro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            parameters.Add("@AutorId", libro.AutorId);
            parameters.Add("@CategoriaId", libro.CategoriaId);
            return await databaseRepository.InsertAsync("INSERT INTO Libros (Titulo, FechaPublicacion, AutorId, CategoriaId) VALUES (@Titulo, @FechaPublicacion, @AutorId, @CategoriaId); SELECT CAST(SCOPE_IDENTITY() AS INT)", parameters);
        }

        public async Task<Libro?> UpdateLibroAsync(Libro libro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.Id);
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            parameters.Add("@AutorId", libro.AutorId);
            parameters.Add("@CategoriaId", libro.CategoriaId);
            await databaseRepository.UpdateAsync<Libro>("UPDATE Libros SET Titulo = @Titulo, FechaPublicacion = @FechaPublicacion, AutorId = @AutorId, CategoriaId = @CategoriaId WHERE Id = @Id", parameters);
            return libro;
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await databaseRepository.DeleteAsync("DELETE FROM Libros WHERE Id = @Id", parameters);
        }
    }
}