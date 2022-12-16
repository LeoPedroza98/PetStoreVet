using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Services;

public interface IVeterinarioService
{
    Task<IEnumerable<Veterinario>> FindAllVet();
    Task<VeterinarioDTO> FindById(long id);
    Task<VeterinarioDTO> Create(VeterinarioDTO vet);
    Task<VeterinarioDTO> Update(VeterinarioDTO vet);
    Task<bool> Delete(long id);
}