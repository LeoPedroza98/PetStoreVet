namespace PetStore.VeterinarioAPI.Data.DTOs;

public class SessionAppDTO
{
    public long UsuarioId { get; set; }
    public string UsuarioNome { get; }
    public string Role { get; set; }
    public string Login { get; set; }

    public SessionAppDTO(long usuarioId, string usuarioNome, string role, string login)
    {
        UsuarioId = usuarioId;
        UsuarioNome = usuarioNome;
        Role = role;
        Login = login;
    }
}