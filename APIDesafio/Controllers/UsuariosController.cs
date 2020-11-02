using APIDesafio.Domain.Entity;
using APIDesafio.Domain.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace APIDesafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;

        public UsuariosController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        // POST api/Usuarios
        /// <summary>
        /// Cria um Usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///        
        ///     {
        ///        "email": "admin@admin.com",
        ///        "password": "admin"
        ///     }    
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Produto</returns>
        /// <response code="200">Retorna o Token de autorização JWT</response>
        /// <response code="400">Se o usuário não for criado</response>  
        [HttpPost("Criar")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return BuildToken(model, _tokenConfigurations, _signingConfigurations);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos.");
            }
        }

        // POST api/Usuarios
        /// <summary>
        /// Efetua Login
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///        
        ///     {
        ///        "email": "admin@admin.com",
        ///        "password": "admin"
        ///     }    
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Produto</returns>
        /// <response code="200">Retorna o Token de autorização JWT</response>
        /// <response code="400">Se o usuário não for criado</response>  
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(userInfo, _tokenConfigurations, _signingConfigurations);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos.");
            }
        }

        private UserToken BuildToken(UserInfo userInfo, TokenConfigurations tokenConfigurations, SigningConfigurations signingConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(userInfo.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                        new Claim("Email", userInfo.Email)
                    }
                );
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new UserToken()
            {
                Authenticated = true,
                Token = token,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                Message = "OK"
            };
        }
    }
}
