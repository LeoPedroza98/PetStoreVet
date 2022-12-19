using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

public class PerfilUsuarioController : MasterQueryController<PerfilUsuario>
{
    public PerfilUsuarioController(ILogger<MasterQueryController<PerfilUsuario>> logger, IQueryService<PerfilUsuario> service) : base(logger, service)
    {
    }
}