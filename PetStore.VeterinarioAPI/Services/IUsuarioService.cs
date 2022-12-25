using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Services;

public interface IUsuarioService
{
    Task Create(UsuarioDTO usuario);
}