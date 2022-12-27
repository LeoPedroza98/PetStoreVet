using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.VeterinarioAPI.Models.Base;

namespace PetStore.VeterinarioAPI.Models.Entities;

[Table("Veterinario")]
public class Veterinario : IEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Column("Nome")]
    [Required]
    [StringLength(50)]
    public string Nome { get; set; }
    [Column("Sobrenome")]
    [Required]
    [StringLength(50)]
    public string Sobrenome { get; set; }
    [Column("CRMV")]
    [Required]
    public string CRMV { get; set; }
    [Column("Especialidade")]
    public long EspecialidadeId { get; set; }
    public Especialidade? Especialidade { get; private set; }
    public Endereco Endereco { get; set; }
    public Contato Contato { get; set; }
}