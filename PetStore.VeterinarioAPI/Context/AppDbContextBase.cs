using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Identity;


namespace PetStore.VeterinarioAPI.Data;

/// <summary>
/// Classe base para o DbContext da aplicação.
/// </summary>
/// <typeparam name="TUser">Entidade derivada de UsuarioBase que representa um Usuário no sistema</typeparam>
/// <typeparam name="TRole">Entidade derivada de UsuarioBase que representa uma Role no sistema</typeparam>
/// <typeparam name="TKey">Chave primária das entidades Usuario e Role</typeparam>
public class AppDbContextBase<TUser, TRole, TKey>:  IdentityDbContext<TUser, TRole, TKey>
    where TUser : IdentityUser<TKey>
    where TRole : IdentityRole<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly ISessaoUsuario _sessaoUsuario;

    public AppDbContextBase(DbContextOptions options, ISessaoUsuario sessaoUsuario) : base(options)
    {
        _sessaoUsuario = sessaoUsuario;
    }
}