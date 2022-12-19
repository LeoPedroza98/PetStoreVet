using PetStore.VeterinarioAPI.Repositories;
using PetStore.VeterinarioAPI.Services;

namespace PetStore.VeterinarioAPI.Extensions;

public static class ServiceExtension
{

    public static void AddInjections(this IServiceCollection services)
    {
        
        services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
        services.AddScoped<IVeterinarioService, VeterinarioService>();
    }
}