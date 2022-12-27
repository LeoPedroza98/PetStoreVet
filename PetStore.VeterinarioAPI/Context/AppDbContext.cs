using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Extensions;
using PetStore.VeterinarioAPI.Identity;
using PetStore.VeterinarioAPI.Models.Entities;
using Pomelo.EntityFrameworkCore;

namespace PetStore.VeterinarioAPI.Data;

public class AppDbContext : AppDbContextBase<Usuario,Role, string>
{
    private readonly ISessaoUsuario _sessaoUsuario;
    public AppDbContext(DbContextOptions options, ISessaoUsuario sessaoUsuario) : base(options, sessaoUsuario)
    {
        _sessaoUsuario = sessaoUsuario;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }


    #region DbSets
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    #endregion
}