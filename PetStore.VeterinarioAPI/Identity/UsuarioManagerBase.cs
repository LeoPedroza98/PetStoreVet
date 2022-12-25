using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Identity;

public class UsuarioManagerBase<TUser> :  UserManager<TUser>, IUsuarioManagerBase<TUser> where TUser : Usuario
{
    public UsuarioManagerBase(
        IUserStore<TUser> store, 
        IOptions<IdentityOptions> options, 
        IPasswordHasher<TUser> passwordHasher, 
        IEnumerable<IUserValidator<TUser>> userValidators, 
        IEnumerable<IPasswordValidator<TUser>> passwordValidators, 
        ILookupNormalizer keyNormalizer, 
        IdentityErrorDescriber errors, 
        IServiceProvider services, 
        ILogger<UserManager<TUser>> logger) : 
        base(store, options, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    { }
}