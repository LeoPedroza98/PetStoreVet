using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }
    
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> Post([FromBody] UsuarioDTO usuario)
    {
        await _service.Create(usuario);
        return Ok();
    }
}