using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Services;
using PetStore.VeterinarioAPI.Utils;

namespace PetStore.VeterinarioAPI.Controllers;

public class UsuarioController : MasterCrudController<Usuario>
{
    private readonly IUsuarioService _service;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service, string includePatch = "") :
        base(logger, service, includePatch)
    {
        _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    public override async Task<ActionResult<Usuario>> Post([FromBody] Usuario model)
    {
        return await base.Post(model);
    }

    [HttpPatch("{id}")]
    public override async Task<IActionResult> Patch(long id, [FromBody] JsonPatchDocument<Usuario> model)
    {
        try
        {
            model.Operations.RemoveAll(x =>
                x.OperationType == Microsoft.AspNetCore.JsonPatch.Operations.OperationType.Test);

            await _service.Patch(id, model, _includePatch);

            return Ok(MensagemHelper.OperacaoSucesso);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

            return StatusCode(StatusCodes.Status500InternalServerError,
                $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
        }
    }

    [HttpGet]
    [AllowAnonymous]
    [CustomAuthorize("Master")]
    public override ActionResult<List<Usuario>> Get(ODataQueryOptions<Usuario> options, [FromHeader] string include)
    {
        try
        {
            var pageResult = GetPageResult(_service.Get(include), options);

            return Ok(pageResult);
        }
        catch (Exception e)
        {
            _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

            return StatusCode(StatusCodes.Status500InternalServerError,
                $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
        }
    }
}