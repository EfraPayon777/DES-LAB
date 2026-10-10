using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.DAL.Interfaces;

public interface IPedidoRepository
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(int id);
    Task<Pedido> AddAsync(Pedido pedido);
    Task<Pedido?> UpdateAsync(Pedido pedido);
    Task<bool> DeleteAsync(int id);
}
