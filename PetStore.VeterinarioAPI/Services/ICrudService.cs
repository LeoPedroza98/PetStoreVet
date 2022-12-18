using Microsoft.AspNetCore.JsonPatch;
using PetStore.VeterinarioAPI.Models.Base;

namespace PetStore.VeterinarioAPI.Services;

public interface ICrudService<TEntity>:IQueryService<TEntity> where TEntity : class,IEntity
{
    Task Post(TEntity entity, bool saveChanges = true);
    Task Post(TEntity entity);
    Task Put(TEntity entity);
    Task Patch(TEntity entity);
    
    Task Patch(long id, JsonPatchDocument<TEntity> model, string include);
    Task Delete(long id);
    Task Delete(TEntity entity);
    Task SaveChangesAsync();
}