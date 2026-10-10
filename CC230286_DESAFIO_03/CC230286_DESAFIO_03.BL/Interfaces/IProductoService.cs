using CC230286_DESAFIO_03.Entities.Dtos;

namespace CC230286_DESAFIO_03.BL.Interfaces;

public interface IProductoService
{
    Task<List<ProductoDto>> GetAllAsync();
    Task<ProductoDto?> GetByIdAsync(int id);
    Task<ProductoDto> CreateAsync(ProductoDto dto);
    Task<ProductoDto?> UpdateAsync(int id, ProductoDto dto);
    Task<bool> DeleteAsync(int id);
}
