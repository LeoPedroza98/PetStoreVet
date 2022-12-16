using PetStore.VeterinarioAPI.Data.DTOs;

namespace PetStore.VeterinarioAPI.Repositories;

public interface IVeterinarioRepository
{
    Task<IEnumerable<VeterinarioDTO>> FindAll();
    Task<VeterinarioDTO> FindById(long id);
    Task<VeterinarioDTO> Create(VeterinarioDTO vet);
    Task<VeterinarioDTO> Update(VeterinarioDTO vet);
    Task<bool> Delete(long id);
}