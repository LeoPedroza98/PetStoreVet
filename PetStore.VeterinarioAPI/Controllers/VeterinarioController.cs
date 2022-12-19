using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;


public class VeterinarioController : MasterCrudController<Veterinario>
{
    private IVeterinarioService _service;
    public VeterinarioController(ILogger<MasterCrudController<Veterinario>> logger, IVeterinarioService service, string includePatch = " ") : base(logger, service, includePatch)
    {
        _service = service;
    }
}