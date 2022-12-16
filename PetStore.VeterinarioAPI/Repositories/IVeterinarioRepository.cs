using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public interface IVeterinarioRepository
{
    Task<IEnumerable<Veterinario>> FindAll();
    Task<Veterinario> FindById(long id);
    Task<Veterinario> Create(Veterinario vet);
    Task<Veterinario> Update(Veterinario vet);
    Task<bool> Delete(long id);
}