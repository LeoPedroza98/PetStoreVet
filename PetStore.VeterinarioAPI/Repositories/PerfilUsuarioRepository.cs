using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public class PerfilUsuarioRepository :  QueryRepository<PerfilUsuario>, IPerfilUsuarioRepository
{
    public PerfilUsuarioRepository(AppDbContext context) : base(context)
    {
    }
}