using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Repositories;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class VeterinarioController : Controller
{
    private IVeterinarioService _service;
    
    public VeterinarioController(IVeterinarioService service)
    {
        _service = service ?? throw new
            ArgumentNullException(nameof(service));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeterinarioDTO>>> FindAll()
    {
        var products = await _service.FindAllVet();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VeterinarioDTO>> FindById(long id)
    {
        var product = await _service.FindById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<VeterinarioDTO>> Create(VeterinarioDTO vet)
    {
        if (vet == null) return BadRequest();
        var product = await _service.Create(vet);
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<VeterinarioDTO>> Update(VeterinarioDTO vet)
    {
        if (vet == null) return BadRequest();
        var product = await _service.Update(vet);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var status = await _service.Delete(id);
        if (!status) return BadRequest();
        return Ok(status);
    }
}