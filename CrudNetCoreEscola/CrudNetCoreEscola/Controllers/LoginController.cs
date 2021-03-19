using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CrudNetCoreEscola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost]
        [Route("AcessoUsuario")]
        public object Login([FromBody] Usuario dados)
        {
            try
            {
                string resultado = new UsuarioService().Login(dados.Email, dados.Senha, _config);
                if (!string.IsNullOrWhiteSpace(resultado))
                {
                    return Ok(new { token = resultado });
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
