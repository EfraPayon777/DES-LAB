using CC230286_DESAFIO_03.DAL.Context;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CC230286_DESAFIO_03.DAL.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _context;

    public ProductoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
    {
        return await _context.Productos.AsNoTracking().ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task<Producto> AddAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto?> UpdateAsync(Producto producto)
    {
        var existing = await _context.Productos.FindAsync(producto.Id);
        if (existing == null)
            return null;

        existing.Nombre = producto.Nombre;
        existing.Descripcion = producto.Descripcion;
        existing.Precio = producto.Precio;
        existing.Stock = producto.Stock;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
            return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Productos.AnyAsync(p => p.Id == id);
    }
}
