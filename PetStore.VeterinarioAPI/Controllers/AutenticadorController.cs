using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Services;
using PetStore.VeterinarioAPI.Utils;

namespace PetStore.VeterinarioAPI.Controllers;

public class AutenticadorController : MasterBaseController
{
    private readonly IAutenticadorService _autenticadorService;
    public AutenticadorController(IAutenticadorService autenticadorService)
    {
        _autenticadorService = autenticadorService;
    }

    [HttpPost("Usuario")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        try
        {
            var retorno = await _autenticadorService.Login(model.Login, model.Senha);
            return Ok(retorno);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
        }
    }
}