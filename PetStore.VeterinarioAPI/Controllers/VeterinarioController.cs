using Microsoft.AspNetCore.Mvc;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Repositories;

namespace PetStore.VeterinarioAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class VeterinarioController : Controller
{
    private IVeterinarioRepository _repository;
    
    public VeterinarioController(IVeterinarioRepository repository)
    {
        _repository = repository ?? throw new
            ArgumentNullException(nameof(repository));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeterinarioDTO>>> FindAll()
    {
        var products = await _repository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VeterinarioDTO>> FindById(long id)
    {
        var product = await _repository.FindById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<VeterinarioDTO>> Create(VeterinarioDTO vet)
    {
        if (vet == null) return BadRequest();
        var product = await _repository.Create(vet);
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<VeterinarioDTO>> Update(VeterinarioDTO vet)
    {
        if (vet == null) return BadRequest();
        var product = await _repository.Update(vet);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var status = await _repository.Delete(id);
        if (!status) return BadRequest();
        return Ok(status);
    }
}