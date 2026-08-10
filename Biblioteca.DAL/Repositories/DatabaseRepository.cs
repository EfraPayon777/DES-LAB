using Biblioteca.Common;
using Biblioteca.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Biblioteca.DAL.Repositories
{
    public class DatabaseRepository(IOptions<AppSettings> appSettings) : IDatabaseRepository
    {
        private readonly string _connectionString = appSettings.Value.ConnectionString;

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                await using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = await connection.QueryAsync<T>(query, parameters);
                connection.Close();
                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta GetDataByQueryAsync: " + e.Message);
            }
        }

        public async Task<int> InsertAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                await using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta InsertAsync: " + e.Message);
            }
        }

        public async Task<T?> UpdateAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                await using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = await connection.QueryAsync<T>(query, parameters);
                connection.Close();

                var enumerable = result.ToList();

                if (enumerable.Any())
                {
                    return enumerable.FirstOrDefault();
                }

                return default;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta UpdateAsync: " + e.Message);
            }
        }

        public async Task<bool> DeleteAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                await using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<bool>(query, parameters);
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta DeleteAsync: " + e.Message);
            }
        }
    }
}