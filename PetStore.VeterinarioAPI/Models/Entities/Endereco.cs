using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PetStore.VeterinarioAPI.Models.Entities;

[Owned]
public class Endereco
{
    [MaxLength(100)] public string Logradouro { get; set; }
    [MaxLength(15)] public string Numero { get; set; }
    [MaxLength(60)] public string Complemento { get; set; }
    [MaxLength(9)]  public string Cep { get; set; }
    [MaxLength(60)] public string Bairro { get; set; }
    [MaxLength(60)] public string Municipio { get; set; }
}