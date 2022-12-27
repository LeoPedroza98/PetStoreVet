using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

public class EspecialidadeController : MasterQueryController<Especialidade>
{
    private readonly IEspecialidadeService _service;

    public EspecialidadeController(ILogger<MasterQueryController<Especialidade>> logger, IQueryService<Especialidade> service) : base(logger, service)
    {
        service = _service;
    }
}