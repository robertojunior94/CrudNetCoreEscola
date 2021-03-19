using CrudNetCoreEscola.Model;
using CrudNetCoreEscola.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudNetCoreEscola.Service
{
    public class UsuarioService
    {
        public Usuario Create(Usuario data)
        {
            return new UsuarioRepository().Create(data);
        }

        public Usuario Update(Usuario data)
        {
            return new UsuarioRepository().Update(data);
        }

        public List<Usuario> ListPaginada(int pagina, int qtdPagina)
        {
            return new UsuarioRepository().ListPaginada(pagina, qtdPagina);
        }

        public string Login(string email, string senha, IConfiguration _config)
        {
            Usuario user = new Usuario();
            string token = null;

            try
            {
                user = new UsuarioRepository().Login(email, senha);

                if (user?.Id > 0)
                {
                    token = GenerateToken(user.Id, user.Nome, user.Perfil.Descricao, _config);
                }
                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;
        }

        public Usuario GetById(int id)
        {
            return new UsuarioRepository().GetById(id);
        }

        public static string GenerateToken(int id, string nome, string perfil, IConfiguration _config)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", id.ToString()),
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, perfil)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
