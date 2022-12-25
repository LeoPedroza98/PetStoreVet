using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Identity;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Utils;

namespace PetStore.VeterinarioAPI.Services;

public class LoginService : ILoginService
{
    private readonly AppDbContext _context;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IConfiguration _configuration;
    ISessaoUsuario _sessaoUsuario;
    private readonly UserManager<Usuario> _userManager;
    private TokenMemoryRepository _tokenRepository;
    
    public LoginService(AppDbContext context, SignInManager<Usuario> signInManager, IConfiguration configuration, ISessaoUsuario sessaoUsuario, 
        UserManager<Usuario> userManager, TokenMemoryRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
        _sessaoUsuario = sessaoUsuario;
        _context = context;
        _signInManager = signInManager;
        _configuration = configuration;
        _userManager = userManager;
    }

    private async Task<UsuarioToken> GeraToken(Usuario usuario)
    {
        ClaimsIdentity identity = new ClaimsIdentity(
            new GenericIdentity(usuario.Id, "login"),
            new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName),
                new Claim("userid", usuario.Id, ClaimValueTypes.String),
                new Claim("name", usuario.Nome ?? "", ClaimValueTypes.String),
                new Claim("username", usuario.UserName, ClaimValueTypes.String),
            }
        );

        var usuarioRoles = await _userManager.GetRolesAsync(usuario);
        if (usuarioRoles.Any())
        {
            identity.AddClaims(
                usuarioRoles.Select(rn => new Claim("role", rn)));
        }
        
        //identity.AddClaim(new Claim("permissions", await _rtoPCalcer.AnalyzePermissionsForUser(identity.Claims)));


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var dataCriacao = DateTime.UtcNow;
        var dataExpiracao = DateTime.UtcNow.AddSeconds(double.Parse(_configuration["TokenConfigurations:Seconds"]));

        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _configuration["TokenConfigurations:Issuer"],
            Audience = _configuration["TokenConfigurations:Audience"],
            SigningCredentials = credenciais,
            Subject = identity,
            NotBefore = dataCriacao,
            Expires = dataExpiracao
        });

        var token = handler.WriteToken(securityToken);

        _tokenRepository.Add(usuario.Id, (securityToken as JwtSecurityToken).Claims.First(c => c.Type == "iat").Value);

        return new UsuarioToken()
        {
            Autenticado = true,
            DataCriacao = dataCriacao.ToString("dd-MM-yyyy HH:mm:ss"),
            TokenDeAcesso = token,
            DataExpiracao = dataExpiracao.ToString("dd-MM-yyyy HH:mm:ss"),
            Mensagem = "Token JWT OK"
        };
    }

    public async Task<UsuarioToken> Login(LoginDTO usuario)
    {
        Usuario userIdentity;

        userIdentity = await _userManager.FindByNameAsync(usuario.UserName);

        if (userIdentity == null)
        {
            throw new BadRequestException("Usuário não encontrado.");
        }
        #if DEBUG
                return await GeraToken(userIdentity);
        #endif

        var login = await _signInManager.PasswordSignInAsync(usuario.UserName, usuario.Password, false, false);

        if (login.Succeeded)
        {

            return await GeraToken(userIdentity);

        }
        else
        {
            throw new UnauthorizedException("Senha incorreta!");
        }
    }
}