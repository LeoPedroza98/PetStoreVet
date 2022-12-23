using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
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
    }
    
}