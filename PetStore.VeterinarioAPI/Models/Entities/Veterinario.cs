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
    [Required]
    [StringLength(150)]
    public string Especialidade { get; set; }
    [Column("Telefone")]
    public string Telefone { get; set; }
    [Column("Email")]
    public string Email { get; set; }
    
}