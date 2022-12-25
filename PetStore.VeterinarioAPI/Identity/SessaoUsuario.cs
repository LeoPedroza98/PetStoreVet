namespace PetStore.VeterinarioAPI.Identity;

public class SessaoUsuario: ISessaoUsuario
{
    public string UsuarioId { get; set; }
    public List<string> Roles { get; set; }
    public string UserName { get; set; }
}