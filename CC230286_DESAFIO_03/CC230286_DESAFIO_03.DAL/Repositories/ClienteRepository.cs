using CC230286_DESAFIO_03.DAL.Context;
using CC230286_DESAFIO_03.DAL.Interfaces;
using CC230286_DESAFIO_03.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CC230286_DESAFIO_03.DAL.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente?> UpdateAsync(Cliente cliente)
    {
        var existing = await _context.Clientes.FindAsync(cliente.Id);
        if (existing == null)
            return null;

        existing.Nombre = cliente.Nombre;
        existing.Apellido = cliente.Apellido;
        existing.Email = cliente.Email;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Clientes.AnyAsync(c => c.Id == id);
    }
}
