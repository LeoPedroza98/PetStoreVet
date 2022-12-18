namespace PetStore.VeterinarioAPI.Utils;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}