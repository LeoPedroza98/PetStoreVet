using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Extensions;
using PetStore.VeterinarioAPI.Models.Entities;
using Pomelo.EntityFrameworkCore;

namespace PetStore.VeterinarioAPI.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }


    #region DbSets
    public DbSet<Veterinario> Veterinarios { get; set; }
    #endregion
}