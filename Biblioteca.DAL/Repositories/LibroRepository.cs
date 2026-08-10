using Biblioteca.DAL.Interfaces;
using Biblioteca.Entites.Models;
using Dapper;

namespace Biblioteca.DAL.Repositories
{
    public class LibroRepository(IDatabaseRepository databaseRepository) : ILibroRepository
    {
        public async Task<List<Libro>> GetLibrosAsync()
        {
            var query = "SELECT * FROM Libros";
            return await databaseRepository.GetDataByQueryAsync<Libro>(query);
        }

        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            var query = "SELECT * FROM Libros WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return (await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters)).FirstOrDefault();
        }

        public async Task<List<Libro>> GetLibrosByEditorialIdAsync(int editorialId)
        {
            var query = "SELECT * FROM Libros WHERE EditorialId = @editorialId";
            var parameters = new DynamicParameters();
            parameters.Add("@editorialId", editorialId);

            return await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters);
        }

        public async Task<int> InsertLibroAsync(Libro libro)
        {
            var query = "INSERT INTO Libros (Titulo, ISBN, EditorialId, Descripcion) VALUES (@Titulo, @ISBN, @EditorialId, @Descripcion); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@ISBN", libro.ISBN);
            parameters.Add("@EditorialId", libro.EditorialId);
            parameters.Add("@Descripcion", libro.Descripcion);

            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Libro?> UpdateLibroAsync(Libro libro)
        {
            var query = "UPDATE Libros SET Titulo = @Titulo, ISBN = @ISBN, EditorialId = @EditorialId, Descripcion = @Descripcion WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", libro.Id);
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@ISBN", libro.ISBN);
            parameters.Add("@EditorialId", libro.EditorialId);
            parameters.Add("@Descripcion", libro.Descripcion);

            await databaseRepository.UpdateAsync<Libro>(query, parameters);
            return libro;
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            var query = "DELETE FROM Libros WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
