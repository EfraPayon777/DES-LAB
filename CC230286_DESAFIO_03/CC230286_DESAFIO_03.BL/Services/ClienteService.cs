using AutoMapper;
using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Dtos;
using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.BL.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return null;

        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<ClienteDto> CreateAsync(ClienteDto dto)
    {
        var entity = _mapper.Map<Cliente>(dto);
        var created = await _repository.AddAsync(entity);
        return _mapper.Map<ClienteDto>(created);
    }

    public async Task<ClienteDto?> UpdateAsync(int id, ClienteDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        existing.Nombre = dto.Nombre;
        existing.Apellido = dto.Apellido;
        existing.Email = dto.Email;

        var updated = await _repository.UpdateAsync(existing);
        return _mapper.Map<ClienteDto>(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
