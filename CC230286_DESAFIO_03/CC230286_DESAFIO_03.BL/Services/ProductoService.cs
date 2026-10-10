using AutoMapper;
using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Dtos;
using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.BL.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;
    private readonly IMapper _mapper;

    public ProductoService(IProductoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductoDto>> GetAllAsync()
    {
        var productos = await _repository.GetAllAsync();
        return _mapper.Map<List<ProductoDto>>(productos);
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null)
            return null;

        return _mapper.Map<ProductoDto>(producto);
    }

    public async Task<ProductoDto> CreateAsync(ProductoDto dto)
    {
        if (dto.Precio <= 0)
            throw new ArgumentException("El precio del producto debe ser mayor a 0.");

        if (dto.Stock < 0)
            throw new ArgumentException("El stock del producto no puede ser negativo.");

        var entity = _mapper.Map<Producto>(dto);
        var created = await _repository.AddAsync(entity);
        return _mapper.Map<ProductoDto>(created);
    }

    public async Task<ProductoDto?> UpdateAsync(int id, ProductoDto dto)
    {
        if (dto.Precio <= 0)
            throw new ArgumentException("El precio del producto debe ser mayor a 0.");

        if (dto.Stock < 0)
            throw new ArgumentException("El stock del producto no puede ser negativo.");

        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        existing.Nombre = dto.Nombre;
        existing.Descripcion = dto.Descripcion;
        existing.Precio = dto.Precio;
        existing.Stock = dto.Stock;

        var updated = await _repository.UpdateAsync(existing);
        return _mapper.Map<ProductoDto>(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
