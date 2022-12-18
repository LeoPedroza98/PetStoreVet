using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public class VeterinarioRepository : CrudRepository<Veterinario>,IVeterinarioRepository
{
    
    private readonly AppDbContext _context;
    private IMapper _mapper;


    public VeterinarioRepository(AppDbContext context) : base(context)
    {
        
    }
}