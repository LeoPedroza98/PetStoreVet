using AutoMapper;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Services;

public class VeterinarioService: CrudService<Veterinario, IVeterinarioRepository>, IVeterinarioService
{
    private readonly IVeterinarioRepository _repository;


    public VeterinarioService(IVeterinarioRepository repository) : base(repository)
    {
        
    }
}