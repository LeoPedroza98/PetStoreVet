namespace PetStore.VeterinarioAPI.Data.DTOs;

public class UsuarioToken
{
    public bool Autenticado { get; set; }
    public string DataCriacao { get; set; }
    public string DataExpiracao{ get; set; }
    public string TokenDeAcesso { get; set; }
    public string Mensagem { get; set; }
}