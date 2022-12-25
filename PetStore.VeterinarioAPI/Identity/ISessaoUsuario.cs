namespace PetStore.VeterinarioAPI.Identity;

public interface ISessaoUsuario
{
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        string UsuarioId { get; set; }
        /// <summary>
        /// Lista contendo os nomes das roles.
        /// </summary>
        List<string> Roles { get; set; }
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        string UserName { get; set; }
}