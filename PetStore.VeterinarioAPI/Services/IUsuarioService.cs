using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Services;

public interface IUsuarioService: ICrudService<Usuario>
{
    Task Post(Usuario usuario, string dominio);
    Task<Usuario> Login(string login, string senha);
    Task AlterarSenha(long id, string senhaAntiga, string senhaNova);
    public Usuario GerarSenha(Usuario usuario);
}