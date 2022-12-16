using Microsoft.EntityFrameworkCore;
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


    #region DbSets

    public DbSet<Veterinario> Veterinarios { get; set; }
    #endregion
}