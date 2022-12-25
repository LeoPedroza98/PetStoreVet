using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Identity;

public class IdentityInitializer
{
    private readonly AppDbContext _context;
    private readonly UserManager<Usuario> _userManager;
    
    public IdentityInitializer(AppDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    private async Task CreateUser(Usuario usuario, string password)
    {
        if (!_userManager.Users.IgnoreQueryFilters().Any(x => x.UserName == usuario.UserName))
        {
            var resultado = await _userManager.CreateAsync(usuario, password);

            if (!resultado.Succeeded)
                throw new InvalidOperationException($"Erro durante a criação da usuário {usuario.UserName}.");
        }

    }
    
    public async Task Initialize()
    {
        await CreateUser(new Usuario
        {
            UserName = "leo",
            //Email = "admin.medsystemcloud@soitic.com",
            //EmailConfirmed = true,
            Nome = "Leonardo",
            Sobrenome = "Pedroza",

        }, "123@Alterar");
    }
}