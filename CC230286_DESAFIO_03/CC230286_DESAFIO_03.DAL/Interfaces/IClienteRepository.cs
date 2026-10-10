using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.DAL.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task<Cliente> AddAsync(Cliente cliente);
    Task<Cliente?> UpdateAsync(Cliente cliente);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
