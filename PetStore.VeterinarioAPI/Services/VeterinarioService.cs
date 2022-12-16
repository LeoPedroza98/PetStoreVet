using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Services;

public class VeterinarioService: IVeterinarioService
{
    private readonly IVeterinarioRepository _repository;


    public VeterinarioService(IVeterinarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Veterinario>> FindAllVet()
    {
        throw new NotImplementedException();
    }

    public Task<Veterinario> FindById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Veterinario> Create(Veterinario vet)
    {
        throw new NotImplementedException();
    }

    public Task<Veterinario> Update(Veterinario vet)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }
}