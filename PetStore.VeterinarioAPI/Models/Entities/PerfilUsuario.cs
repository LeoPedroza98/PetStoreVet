using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.VeterinarioAPI.Models.Base;

namespace PetStore.VeterinarioAPI.Models.Entities;

public class PerfilUsuario : IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] public long Id { get; set; }
    [MaxLength(60)] public string Nome { get; set; }
    [MaxLength(255)] public string Role { get; set; }


    [NotMapped] public static PerfilUsuario Master => new PerfilUsuario(1, "Master", "Master");


    public PerfilUsuario(long id, string nome, string role)
    {
        Id = id;
        Nome = nome;
        Role = role;
    }

    public static PerfilUsuario[] ObterDados()
    {
        return new PerfilUsuario[]
        {
            Master
        };
    }
}