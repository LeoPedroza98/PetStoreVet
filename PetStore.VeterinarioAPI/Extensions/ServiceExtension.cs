using Microsoft.Extensions.DependencyInjection.Extensions;
using PetStore.VeterinarioAPI.Identity;
using PetStore.VeterinarioAPI.Repositories;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Extensions;

public static class ServiceExtension
{

    public static void AddInjections(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
        services.AddScoped<IVeterinarioService, VeterinarioService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ISessaoUsuario, SessaoUsuario>();
        services.AddSingleton<TokenMemoryRepository>();
        services.AddTransient<TokenValidationMiddleware>();
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        services.AddScoped<IEspecialidadeService, EspecialidadeService>();
    }
    
}