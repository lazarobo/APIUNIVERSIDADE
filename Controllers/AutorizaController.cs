using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIUNIVERSIDADE.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIUNIVERSIDADE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AutorizaController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
            public ActionResult<string> Get(){
                return "AutorizaController:: Acessado em : "
                    + DateTime.Now.ToLongDateString(); 
            }
        [HttpPost("register")]
            public async Task<ActionResult> RegisterUser([FromBody]UsuarioDTO model){
                var user = new IdentityUser{
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(!result.Succeeded)
                    return BadRequest(result.Errors);

                await _signInManager.SignInAsync(user, false);
                return Ok();    
            }

        [HttpPost("login")]
            public async Task<ActionResult> Login([FromBody] UsuarioDTO userInfo){
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                if(result.Succeeded)
                    return Ok();
                else{
                    ModelState.AddModelError(string.Empty,"Login inválido...");
                        return BadRequest(ModelState);
                }
            }
        
        private usuarioToken GeraToken(UsuarioDTO userInfo){
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userInfo.Email),
                new Claim("IFRN", "tecInfo."),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
        var key = new SymetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:key"])
        );

        }

    }
}