using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public interface IUsuarioRepository: ICrudRepository<Usuario>
{
    Task<Usuario> Login(string login);
}