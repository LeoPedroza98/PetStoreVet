using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Data;

public static class ModelBuilderExtensions
{
    public static void Seed (this ModelBuilder modelBuilder)
    {
        #region Geral
        modelBuilder.Entity<Especialidade>().HasData(Especialidade.ObterDados());
        #endregion
    }
}