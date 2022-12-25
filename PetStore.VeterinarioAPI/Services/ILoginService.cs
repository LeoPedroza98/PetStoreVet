using PetStore.VeterinarioAPI.Data.DTOs;

namespace PetStore.VeterinarioAPI.Services;

public interface ILoginService
{
    Task<UsuarioToken> Login(LoginDTO usuario);
}