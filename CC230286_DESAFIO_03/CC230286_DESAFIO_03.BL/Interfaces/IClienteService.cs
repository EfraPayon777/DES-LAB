using CC230286_DESAFIO_03.Entities.Dtos;

namespace CC230286_DESAFIO_03.BL.Interfaces;

public interface IClienteService
{
    Task<List<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task<ClienteDto> CreateAsync(ClienteDto dto);
    Task<ClienteDto?> UpdateAsync(int id, ClienteDto dto);
    Task<bool> DeleteAsync(int id);
}
