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
    
    public async Task<IEnumerable<VeterinarioDTO>> FindAll()
    {
        List<Veterinario> products = await _context.Veterinarios.ToListAsync();
        return _mapper.Map<List<VeterinarioDTO>>(products);
    }
    
    public async Task<VeterinarioDTO> FindById(long id)
    {
        Veterinario vet =
            await _context.Veterinarios.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        return _mapper.Map<VeterinarioDTO>(vet);
    }
    
    public async Task<VeterinarioDTO> Create(VeterinarioDTO vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        _context.Veterinarios.Add(veterinario);
        await _context.SaveChangesAsync();
        return _mapper.Map<VeterinarioDTO>(veterinario);
    }
    
    public async Task<VeterinarioDTO> Update(VeterinarioDTO vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        _context.Veterinarios.Update(veterinario);
        await _context.SaveChangesAsync();
        return _mapper.Map<VeterinarioDTO>(veterinario);
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