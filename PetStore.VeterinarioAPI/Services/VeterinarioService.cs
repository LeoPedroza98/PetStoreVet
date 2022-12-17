using AutoMapper;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Services;

public class VeterinarioService: IVeterinarioService
{
    private readonly IVeterinarioRepository _repository;
    private IMapper _mapper;


    public VeterinarioService(IVeterinarioRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Veterinario>> FindAllVet()
    {
        IEnumerable<Veterinario> veterinarios = await _repository.FindAll();
        return _mapper.Map<IEnumerable<Veterinario>>(veterinarios);
    }

    public async Task<VeterinarioDTO> FindById(long id)
    {
        Veterinario vet = await _repository.FindById(id);
        return _mapper.Map<VeterinarioDTO>(vet);
    }

    public async Task<VeterinarioDTO> Create(VeterinarioDTO vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        await _repository.Create(veterinario);
        return _mapper.Map<VeterinarioDTO>(veterinario);
    }

    public async Task<VeterinarioDTO> Update(VeterinarioDTO vet)
    {
        Veterinario veterinario = _mapper.Map<Veterinario>(vet);
        await _repository.Update(veterinario);
        return _mapper.Map<VeterinarioDTO>(veterinario);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            Veterinario veterinario = await _repository.FindById(id);
            if (veterinario == null) return false;
            await _repository.Delete(veterinario.Id);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}