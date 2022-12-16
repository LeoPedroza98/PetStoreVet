using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public class VeterinarioRepository : IVeterinarioRepository
{
    
    private readonly AppDbContext _context;
    private IMapper _mapper;

    public VeterinarioRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Veterinario>> FindAll()
    {
        List<Veterinario> products = await _context.Veterinarios.ToListAsync();
        return products;
    }
    
    public async Task<Veterinario> FindById(long id)
    {
        Veterinario vet = await _context.Veterinarios.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        return vet;
    }
    
    public async Task<Veterinario> Create(Veterinario vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        _context.Veterinarios.Add(veterinario);
        await _context.SaveChangesAsync();
        return veterinario;
    }
    
    public async Task<Veterinario> Update(Veterinario vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        _context.Veterinarios.Update(veterinario);
        await _context.SaveChangesAsync();
        return veterinario;
    }
    
    public async Task<bool> Delete(long id)
    {
        try
        {
            Veterinario veterinario =
                await _context.Veterinarios.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            if (veterinario == null) return false;
            _context.Veterinarios.Remove(veterinario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}