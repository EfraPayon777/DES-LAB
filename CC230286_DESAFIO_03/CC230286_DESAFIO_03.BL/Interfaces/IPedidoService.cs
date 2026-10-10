using CC230286_DESAFIO_03.Entities.Dtos;

namespace CC230286_DESAFIO_03.BL.Interfaces;

public interface IPedidoService
{
    Task<List<PedidoDto>> GetAllAsync();
    Task<PedidoDto?> GetByIdAsync(int id);
    Task<PedidoDto> CreateAsync(PedidoDto dto);
    Task<bool> DeleteAsync(int id);
}
