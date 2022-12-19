namespace PetStore.VeterinarioAPI.Services;

public interface IAutenticadorService
{
    Task<object> Login(string login, string senha);
}