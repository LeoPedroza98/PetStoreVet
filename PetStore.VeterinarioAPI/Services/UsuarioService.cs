using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Utils;

namespace PetStore.VeterinarioAPI.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IConfiguration _configuration;


    public UsuarioService(AppDbContext context, IMapper mapper, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public async Task Create(UsuarioDTO usuario)
    {
        var u = _mapper.Map<UsuarioDTO, Usuario>(usuario);

        var resultado = await _userManager.CreateAsync(u, usuario.Password);

        if (!resultado.Succeeded)
        {
            throw new BadRequestException(resultado.Errors.ToList()[0].Description);
        }

        await _signInManager.SignInAsync(u, isPersistent: false);

    }
}