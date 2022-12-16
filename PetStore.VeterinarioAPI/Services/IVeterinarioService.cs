using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Services;

public interface IVeterinarioService
{
    Task<IEnumerable<Veterinario>> FindAllVet();
    Task<Veterinario> FindById(long id);
    Task<Veterinario> Create(Veterinario vet);
    Task<Veterinario> Update(Veterinario vet);
    Task<bool> Delete(long id);
}