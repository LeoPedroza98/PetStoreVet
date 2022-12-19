using Microsoft.EntityFrameworkCore;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Repositories;

public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {
    }

    public override void Update(Usuario entity)
    {
        _context.Entry(entity).Property(x => x.Login).IsModified = false;

        base.Update(entity);
    }

    public async Task<Usuario> Login(string login)
    {
        var usuario = await _context.Usuarios
            .Include(x => x.Perfil)
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(x => x.Login.ToUpper() == login.ToUpper());

        return usuario;
    }
}