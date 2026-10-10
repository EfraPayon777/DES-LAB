using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.DAL.Interfaces;

public interface IProductoRepository
{
    Task<List<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> AddAsync(Producto producto);
    Task<Producto?> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
