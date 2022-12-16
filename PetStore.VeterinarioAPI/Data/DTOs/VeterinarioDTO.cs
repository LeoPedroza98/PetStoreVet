using PetStore.VeterinarioAPI.Models.Base;

namespace PetStore.VeterinarioAPI.Data.DTOs;

public class VeterinarioDTO : IEntity
{
    public long Id { get; set; }
    
    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string CRMV { get; set; }

    public string Especialidade { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }
}