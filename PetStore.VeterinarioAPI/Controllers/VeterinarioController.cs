using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Repositories;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class VeterinarioController : MasterCrudController<Veterinario>
{
    private IVeterinarioService _service;


    public VeterinarioController(ILogger<MasterCrudController<Veterinario>> logger, ICrudService<Veterinario> service, string includePatch = "") : base(logger, service, includePatch)
    {
    }
}