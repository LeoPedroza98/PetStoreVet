using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PetStore.VeterinarioAPI.Models.Entities;

[Owned]
public class Contato
{
    [MaxLength(60)] public string Nome { get; set; }
    [MaxLength(15)] public string Telefone { get; set; }
    [MaxLength(15)] public string Celular { get; set; }
    [MaxLength(255)] public string Email { get; set; }
}