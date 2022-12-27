using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public class EspecialidadeRepository : QueryRepository<Especialidade>,IEspecialidadeRepository
{
    public EspecialidadeRepository(AppDbContext context) : base(context)
    {
    }
}