using CC230286_DESAFIO_03.DAL.Context;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CC230286_DESAFIO_03.DAL.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _context;

    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Producto)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Pedido?> GetByIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Producto)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pedido> AddAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido?> UpdateAsync(Pedido pedido)
    {
        var existing = await _context.Pedidos.FindAsync(pedido.Id);
        if (existing == null)
            return null;

        existing.FechaPedido = pedido.FechaPedido;
        existing.Cantidad = pedido.Cantidad;
        existing.ClienteId = pedido.ClienteId;
        existing.ProductoId = pedido.ProductoId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido == null)
            return false;

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
}
