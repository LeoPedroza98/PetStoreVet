using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class LoginController : Controller
{
    private readonly ILoginService _service;
    public LoginController(ILoginService usuariosService)
    {
        _service = usuariosService;
    }

    // POST api/Login
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginDTO usuario)
    {
        var token = await _service.Login(usuario);
        return Ok(token);
    }

}