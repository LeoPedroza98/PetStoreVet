using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Services;

public class PerfilUsuarioService : QueryService<PerfilUsuario, IPerfilUsuarioRepository>, IPerfilUsuarioService
{
    public PerfilUsuarioService(IPerfilUsuarioRepository repository) : base(repository)
    {
    }
}