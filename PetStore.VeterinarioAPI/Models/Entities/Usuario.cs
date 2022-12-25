using Microsoft.AspNetCore.Identity;
using PetStore.VeterinarioAPI.Identity;

namespace PetStore.VeterinarioAPI.Models.Entities;

public class Usuario : UsuarioBase
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool AcessoHabilitado { get; set; }
    public DateTime DataRegistro { get; set; }
    
    public Usuario()
    {
        AcessoHabilitado = true;
        DataRegistro = DateTime.Now;
    }
}