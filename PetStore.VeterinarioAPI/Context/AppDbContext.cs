using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Extensions;
using PetStore.VeterinarioAPI.Models.Entities;
using Pomelo.EntityFrameworkCore;

namespace PetStore.VeterinarioAPI.Data;

public class AppDbContext : DbContext
{
    // public SessionAppDTO SessionApp { get; }
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        modelBuilder.Entity<Usuario>().HasIndex(x => x.Login).IsUnique();
        modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
    }


    #region DbSets
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    #endregion
}