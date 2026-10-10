using AutoMapper;
using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Dtos;
using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.BL.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly IMapper _mapper;

    public PedidoService(
        IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository,
        IProductoRepository productoRepository,
        IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
        _productoRepository = productoRepository;
        _mapper = mapper;
    }

    public async Task<List<PedidoDto>> GetAllAsync()
    {
        var pedidos = await _pedidoRepository.GetAllAsync();
        return _mapper.Map<List<PedidoDto>>(pedidos);
    }

    public async Task<PedidoDto?> GetByIdAsync(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
            return null;

        return _mapper.Map<PedidoDto>(pedido);
    }

    public async Task<PedidoDto> CreateAsync(PedidoDto dto)
    {
        if (dto.Cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a 0.");

        var cliente = await _clienteRepository.GetByIdAsync(dto.ClienteId);
        if (cliente == null)
            throw new KeyNotFoundException($"El cliente con Id {dto.ClienteId} no existe.");

        var producto = await _productoRepository.GetByIdAsync(dto.ProductoId);
        if (producto == null)
            throw new KeyNotFoundException($"El producto con Id {dto.ProductoId} no existe.");

        if (producto.Stock < dto.Cantidad)
            throw new InvalidOperationException($"Stock insuficiente. Stock disponible: {producto.Stock}, cantidad solicitada: {dto.Cantidad}.");

        producto.Stock -= dto.Cantidad;
        await _productoRepository.UpdateAsync(producto);

        var entity = _mapper.Map<Pedido>(dto);
        if (entity.FechaPedido == default)
            entity.FechaPedido = DateTime.UtcNow;

        var created = await _pedidoRepository.AddAsync(entity);
        var resultWithDetails = await _pedidoRepository.GetByIdAsync(created.Id);

        return _mapper.Map<PedidoDto>(resultWithDetails ?? created);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
            return false;

        var producto = await _productoRepository.GetByIdAsync(pedido.ProductoId);
        if (producto != null)
        {
            producto.Stock += pedido.Cantidad;
            await _productoRepository.UpdateAsync(producto);
        }

        return await _pedidoRepository.DeleteAsync(id);
    }
}
