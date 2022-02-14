using ApiVideoclubNC.Helpers;
using ApiVideoclubNC.Models;
using ApiVideoclubNC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryPeliculas repo;
        private HelperOAuthToken helper;

        public AuthController(RepositoryPeliculas repo, HelperOAuthToken helper)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Cliente cliente =
                this.repo.ExisteCliente(model.Username, int.Parse(model.Password));
            Administrador admin =
                this.repo.ExisteAdmin(model.Username, int.Parse(model.Password));
            if(cliente == null || admin == null)
            {
                return Unauthorized();
            }
            else if(cliente != null)
            {
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(cliente))
                };

                JwtSecurityToken token =
                    new JwtSecurityToken(
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(20),
                        notBefore: DateTime.UtcNow,
                        signingCredentials:
                        new SigningCredentials(
                            this.helper.GetKeyToken(), 
                            SecurityAlgorithms.HmacSha256)
                        );
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }

            else
            {
                Claim[] claims = new[]
                {
                    new Claim("UserData",
                    JsonConvert.SerializeObject(admin))
                };

                JwtSecurityToken token =
                    new JwtSecurityToken(
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(20),
                        notBefore: DateTime.UtcNow,
                        signingCredentials:
                        new SigningCredentials(
                            this.helper.GetKeyToken(),
                            SecurityAlgorithms.HmacSha256)
                        );
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }
    }
}
