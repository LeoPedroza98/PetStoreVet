using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Services;

public class EspecialidadeService: QueryService<Especialidade,IEspecialidadeRepository>,IEspecialidadeService
{
    public EspecialidadeService(IEspecialidadeRepository repository) : base(repository)
    {
    }
}