using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        #region All
        modelBuilder.Entity<PerfilUsuario>().HasData(PerfilUsuario.ObterDados());
        #endregion
    }
}