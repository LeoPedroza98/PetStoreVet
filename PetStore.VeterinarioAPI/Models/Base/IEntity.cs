using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.VeterinarioAPI.Models.Base;

public interface IEntity
{
    public long Id { get; set; }
}