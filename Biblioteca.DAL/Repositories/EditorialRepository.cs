using Biblioteca.DAL.Interfaces;
using Biblioteca.Entites.Models;
using Dapper;

namespace Biblioteca.DAL.Repositories
{
    public class EditorialRepository(IDatabaseRepository databaseRepository) : IEditorialRepository
    {
        public async Task<List<Editorial>> GetEditorialesAsync()
        {
            var query = "SELECT * FROM Editoriales";
            return await databaseRepository.GetDataByQueryAsync<Editorial>(query);
        }

        public async Task<Editorial?> GetEditorialByIdAsync(int id)
        {
            var query = "SELECT * FROM Editoriales WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return (await databaseRepository.GetDataByQueryAsync<Editorial>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertEditorialAsync(Editorial editorial)
        {
            var query = "INSERT INTO Editoriales (Nombre, Pais) VALUES (@Nombre, @Pais); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", editorial.Nombre);
            parameters.Add("@Pais", editorial.Pais);

            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Editorial?> UpdateEditorialAsync(Editorial editorial)
        {
            var query = "UPDATE Editoriales SET Nombre = @Nombre, Pais = @Pais WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", editorial.Id);
            parameters.Add("@Nombre", editorial.Nombre);
            parameters.Add("@Pais", editorial.Pais);

            await databaseRepository.UpdateAsync<Editorial>(query, parameters);
            return editorial;
        }

        public async Task<bool> DeleteEditorialAsync(int id)
        {
            var query = "DELETE FROM Editoriales WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
