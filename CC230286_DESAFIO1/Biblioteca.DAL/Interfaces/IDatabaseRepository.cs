using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace CC230396_Desafio01.DAL.Interfaces
{
    public interface IDatabaseRepository
    {
        public Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null);
        public Task<int> InsertAsync(string query, DynamicParameters? parameters = null);
        public Task<T?> UpdateAsync<T>(string query, DynamicParameters? parameters = null);
        public Task<bool> DeleteAsync(string query, DynamicParameters? parameters = null);
    }
}
